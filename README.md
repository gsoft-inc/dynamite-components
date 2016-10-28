Dynamite-Components
===================

Reusable components and modules for SharePoint 2013 based on the Dynamite (2013) toolkit

* [NuGet Feeds](#nuget-feeds)
* [Model NuGet Packages](#model-nuget-packages) - The provisioning recipes
* [Module Contract NuGet Packages](#module-contract-nuget-packages) - Configuration and plug-in hooks for the components being provisioned by the models

> **New to GSoft-SharePoint's Dynamite?** Head to the core [Dynamite project readme] to learn the basics first.

> For some extra background (in French) about Dynamite and the modular approach behind Dynamite-Components, please refer to [GSOFT's dev practices guide g.gsoft.com](http://g.gsoft.com/sharepoint/intro).


NuGet Feeds
===========

Subscribe to the stable Dynamite 2013 public [MyGet.org](http://www.myget.org) feed: 

* [NuGet v2 - VS 2012+](https://www.myget.org/F/dynamite-2013/api/v2)
* [NuGet v3 - VS 2015+](https://www.myget.org/F/dynamite-2013/api/v3/index.json)

Pre-release builds [are available from a separate feed](https://github.com/GSoft-SharePoint/Dynamite/wiki/Installing-the-Dynamite-NuGet-packages-from-our-MyGet.org-feeds).

Beyond the foundational `GSoft.Dynamite` and `GSoft.Dynamite.SP` NuGet packages, a great number of NuGet packages are available from the feed that are related to the Dynamite-Components project.

Model NuGet Packages
====================

Dynamite-Components' models are A-to-Z-automated SharePoint configuration recipes, driven by PowerShell scripts and extensible through an architecture Autofac registration modules.

## 1. `GSoft.Dynamite.StandardPublishingCMS` - A Classic SharePoint Publishing Model

The simpler of the two models. Based on the Classic Publishing features of SharePoint, it provisions a standardized-yet-configurable information architecture that leverages many standard OOTB SharePoint concepts:

* Pages library
* ASPX page layouts
* Taxonomy navigation
* Variations 

Start by creating an empty class library project in Visual Studio (e.g. `Company.MyProject.SetupScripts`), then install the `GSoft.Dynamite.StandardPublishingCMS` NuGet package.

A few scripts will be created for you, along with configuration files arranged in a folder hierarchy.

Your workflow should be the following (make sure you have [the DSP PowerShell toolkit](https://github.com/GSoft-SharePoint/Dynamite#b-automating-your-deployments-with-powershell) already installed):

1. Adjust your `Tokens.HOSTNAME.ps1` file to a configuration of your liking
2. Optionally, adjust the main setup script `Install-Model.template.ps1` to customize your provisioning sequence
    * Don't forget to include the path to your own WSP solution packages in `\Solutions\Custom\Custom-Solutions.template.xml` to make sure they get deployed (use `\Solutions\Default\Default-Solutions.template.xml` as an example of how to configure your WSP deployment)
    * You can provide a replacement PowerShell script for all the `.ps1` files included in the standard provisioning sequence (same holds for all `.xml` config files). Just place your replacement script in your project at the same position than the file you mean to replace is within the package folder at: `\packages\GSoft.Dynamite.StandardPublishingCMS-3.2.0\tools\Modules`
3. Launch `Publish-DeploymentFolder.ps1`, which:
    1. Creates a `/Deployment` folder at the root of your solution
    2. Merges the contents of `\packages\GSoft.Dynamite.StandardPublishingCMS-3.2.0\tools\` with the file contents of your own Visual Studio project. Your scripts and config files take precedence and override the default `.ps1` and `.xml` files found in the NuGet packages `\tools\` subfolder.
    3. Copies all .WSP solution packages found in the solution to the `\Deployment` folder
    4. Optionally `cd`s you into the `\Deployment` folder if you specify the `-SetLocationToDestination` option
4. Your deployment archive (`\Deployment`) is now ready.
5. From `\Deployment`, instantiate your own environment-specific scripts and config with `Update-DSPTokens`
    * Converts all `.template.ps1` and `.template.xml` files into `.ps1` and `.xml` files by replacing all `[[DSP_*]]` tokens in them with the variable values defined in you own `Tokens.HOSTNAME.ps1` master configuration file)
6. Launch `.\Solutions\Deploy-Solutions.ps1`. When done, close your PowerShell window.
7. In a new shell, launch `.\Install-Model.ps1`: the PowerShell-driven site creation and feature activation provisioning sequence will be launched.
    * Take the time to familiarize yourself with the full installation sequence by stepping down the different sub-scripts called from `.\Install-Model.ps1`
8. Profit! You have a full Intranet Portal configured with very little effort.

Of course, things get more complicated as start customizing the provisioning configuration for each of Dynamite-Components modules.

> **For GSOFT developers only:** the best example your can rely on as a real-world use of this model is the [Desjardins DFS website](http://www.dfs.ca) which is well-documented in the private Bitbucket repo.

## 2. `GSoft.Dynamite.CrossSitePublishingCMS` - A Cross-site Publishing Model

This CMS-provisioning recipe is more complex, since it uses SharePoint 2013's cross-site publishing features (thus a lot of Search Service configuration) to build a full taxonomy-navigation and search-driven publishing solution.

You should choose this option only if you require de-centralized content publication (e.g. you have tons of content creator teams or you can't/won't let them access the final publishing site).

> The main drawback of cross-site publishing is the wait time (i.e. the delay due to search indexing) that the users - stuck in their tiny authoring site - need to tolerate before their content finally appears in the publishing site.

The developer workflow is the same as the `StandardPublishingCMS`. In an empty project `Company.MyProject.SetupScripts`, install the `CrossSitePublishingCMS` NuGet package then:

1. Customize your tokens, input XML and scripts
2. Prepare a `\Deployment` folder with `.\Publish-DeploymentFolder.ps1`
3. Instantiate your dev-env-specific scripts with `Update-DSPTokens`
4. Install all WSPs with `\Solutions\Deploy-Solutions.ps1`
5. In a new shell, launch the setup sequence with `Install-Model.ps1`
6. Profit! You have a full Intranet Portal configured with very little effort.

> GSOFT devs: refer to the [Nunavik parks website](http://www.nunavikparks.ca/en) project which is based on the `CrossSitePublishingCMS`


Module Contract NuGet Packages
==============================

If you wish to customize your `StandardPublishingCMS` or your `CrossSitePublishingCMS` setup sequence, beyond adjusting the default Tokens, PowerShell and XML (for term store and site hierarchy initialization), you will need to implement specific contracts and register some Autofac modules to apply these configuration overrides.

The various Dynamite-Components C# extension points are exposed through the following `*.Contracts` NuGet packages:

### 1. Foundational modules: 

* A common base: `GSoft.Dynamite.Common.Contracts`
    * Holds some global taxonomy and search-related configuration contracts
* Publishing components ("PUB" for short): `GSoft.Dynamite.Publishing.Contracts`
    * Page and item content type definitions
    * Basic page layouts for classic and cross-site publishing scenarios
* Navigation components ("NAV"): `GSoft.Dynamite.Navigation.Contracts`
    * Menus and a taxonomy-navigation based information architecture
* Document components ("DOC"): `GSoft.Dynamite.Docs.Contracts`
    * Document library configuration

### 2. Functional modules

* Search ("SRCH"): `GSoft.Dynamite.Search.Contracts`
    * Managed property and result source configuration
* Multilingual support ("LANG"): `GSoft.Dynamite.Multilingualism.Contracts`
    * Variations configuration hooks
* Security and content lifecycle ("LFCL"): `GSoft.Dynamite.Lifecycle.Contracts`
* Social ("SOCIAL"): `GSoft.Dynamite.Social.Contracts`
* Content targeting ("TARGET"): `GSoft.Dynamite.Targeting.Contracts`

### 3. Complementary modules

* Branding ("DSGN"): `GSoft.Dynamite.Design.Contracts`
    * Master page and CSS provisioning configuration
* Migration ("MIG"): `GSoft.Dynamite.Migration.Contracts` 
    * Extensible migration framework configuration


How to extend/replace/configure the Dynamite-Components modules
===============================================================

Dynamite-Components is a provisioning framework. It provides extension points (in the form of C# contract interfaces to implement) to customize the `StandardPublishingCMS` and `CrossSitePublishingCMS` provisioning models.

Start by creating your own Service Locator project (e.g. `Company.MyProject.ServiceLocator`). Make sure you use the `*.ServiceLocator` postfix to end you project assemble name. In our example, once deployed to the GAC, the file `Company.MyProject.ServiceLocator.dll` should be in the `GAC_MSIL` folder.

Take care to implement the `ISharePointServiceLocatorAccessor` interface while building your own `SharePointServiceLocator`:

```
public class MyProjectContainer : ISharePointServiceLocatorAccessor
{
    private const string AppName = "Company.Project";

    private static ISharePointServiceLocator SingletonLocatorInstance = new SharePointServiceLocator(AppName);

    public ISharePointServiceLocator ServiceLocatorInstance 
    {
        get
        {
            return SingletonLocatorInstance;
        }
    }

    public static ILifetimeScope BeginLifetimeScope()
    {
        return SingletonLocatorInstance.BeginLifetimeScope();
    }

    public static ILifetimeScope BeginLifetimeScope(SPFeature feature)
    {
        return SingletonLocatorInstance.BeginLifetimeScope(feature);
    }

    public static ILifetimeScope BeginLifetimeScope(SPWeb web)
    {
        return InnerServiceLocator.BeginLifetimeScope(web);
    }
}
```

Next, in your project `Company.MyProject.SetupScripts` make sure that you configure your token variable `$DSP_ServiceLocatorAssemblyName` to `"Company.MyProject.ServiceLocator"`.

### The great GAC-assembly scanning voodoo logic that makes this all work
 
Provisioning process goes like this:
 
1. You start the PowerShell `Install-Model.ps1` process
2. A feature from the PUB module is activated (i.e. a SharePoint feature event receiver defined in the `GSoft.Dynamite.Publishing.SP` project is activated)
3. Within feature activation code, a the PUB module's `AddOnProvidedServiceLocator` is used to resolve a particular configuration component (e.g. we want to resolve the `IPublishingFieldsConfig` to determine which site columns to provision)
4. **MAGIC BIT #1**: the `AddOnProvidedServiceLocator` looks in the current `SPWeb`'s property bag, then in the root web's property bag, then up in the web application property bag for the key "ServiceLocatorAssemblyName" to determine what the filename of the DLL holding the `Company.Project.ServiceLocator` class is.
    * i.e. your `Company.Project` is an "add-on" to the Dynamite-Components framework
5. The GAC is scanned for this assembly file name, the DLL is loaded and then scanned to find the class implementing `ISharePointServiceLocatorAccessor`
6. Your own `MyProjectContainer` is found and used to resolve the `IPublishingFieldsConfig` interface
7. **MAGIC BIT #2**: Attempting an interface resolution on the `MyProjectContainer` triggers the 2nd GAC assembly scan. This is now the regular `SharePointServiceLocator` GAC-scanning process where all assemblies matching your container's `AppName` (i.e. all DLLs starting with `Company.MyProject`) will be loaded and scanned for Autofac registration modules.
8. Maybe you defined an Autofac registration module that registers your own custom `FieldConfig` that enhances the basic Dynamite-Components like so:

```
// Somewhere in your own Autofac registration module's .Load method
builder.Register(c => new FieldConfig(c.ResolveNamed<IPublishingFieldInfoConfig>("publishing")))
    .As<IPublishingFieldInfoConfig>()
    .Named<IPublishingFieldInfoConfig>("MyProject");
```

For completeness' sake, here is an example `FieldConfig`:
```
public class FieldConfig : IPublishingFieldInfoConfig
{
    private IPublishingFieldInfoConfig publishingFieldInfoConfig;

    public FieldConfig(IPublishingFieldInfoConfig publishingFieldInfoConfig)
    {
        // keep a reference on the default list of
        // fields configured by Dynamite-Components
        this.publishingFieldInfoConfig = publishingFieldInfoConfig;
    }

    /// Returns the updated fields configuration we want to apply to our site
    public IList<BaseFieldInfo> Fields
    {
        get 
        {
            var baseFields = this.publishingFieldInfoConfig.Fields;

            // Add our own fields
            baseFields.Add(MyPageFields.RightSidebarHtmlContent);
            baseFields.Add(MyPageFields.ContextualMenuTopLevel);
            baseFields.Add(MyPageFields.CanonicalUrl);

            // Return enhanced list of fields to be provisioned
            // by a feature part of the GSoft.Dynamite.Publishing.SP
            // solution package WSP
            return baseFields;
        }
    }

    // A bit of boilerplate
    public BaseFieldInfo GetFieldById(Guid fieldId)
    {
        return this.publishingFieldInfoConfig.GetFieldById(fieldId);
    }
}
```

> Note how the `FieldConfig` customized for `MyProject` take the default IPublishingFieldsConfig (which can be resolved as a named instance through the keywork "publishing") as a parameter to its constructor. Injecting your own class with the base definitions allows you to extend the original list instead of replacing it entirely.

Finally, your custom `FieldConfig` "plug-in" is used to provision your customized list of fields. You've successfully overriden Dynamite-Components' default `IPublishingFieldsConfig`.

Whew, we made it!
