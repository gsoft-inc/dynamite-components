# ----------------------------------------
# MIG 01: IMPORT CONTENT
# ----------------------------------------

-------------------------------------------------------------------------------------------------------------------------------------------
##### GESTION DU MULTILINGUE
-------------------------------------------------------------------------------------------------------------------------------------------
Si votre solution est multilingue ($DSP_IsMultilingual = $true) dans votre fichier de tokens personnel,
alors vous devez respecter la structure de dossiers suivante:

[DOC_02]
	- Custom
		- [Source Label]
		- [Label 1]
		- [Label n]

Le nom de dossier pour chaque label doit correspondre à ceux que vous avez mis adans votre fichier de tokens ($DSP_VariationsLabels). 
Exemple: $DSP_VariationsLabels = @('en','fr','jb') ==> [MIG_01]
														- Custom
															- en
															- fr
															- jb

Si votre solution n'est pas mulitlingue vous pouvez mettre vos fichiers EXcel de mappings directement sous /Custom (Voir l'exemple avec /Default)


-------------------------------------------------------------------------------------------------------------------------------------------
##### CRÉATION DES FICHIERS EXCEL D'IMPORT
-------------------------------------------------------------------------------------------------------------------------------------------
- Ne pas enlevez les colones "Created", "Created By", "Modified" et "Modified By" (même vides) des fichiers Excel. SharGate en a besoin lors de l'import (=bug)

- Vous devrez générer un fichier "*.sgt" correpondant au template d'importation et indiquant le mapping entre les colonnes. 
Pour le générer, suivez les étapes suivamtes:

	- #1: Créer une liste dans un de vos site d'authoring (peut importe lequel)
	- #2 Ajoutez TOUT les types de contenus (les plus creux de la hiérarchie) de votre application dans la liste (Ex: News Item, Content Item)
	- #3 Ouvrez ShareGate et simuler un "Copy Content" avec votre liste nouvellement créée en tant que destination (peut importe la source)
	- #4 Sélectionnez "Import from Excel"
	- #5 Sélectionnez votre fichier Excel (un qui mappe un des content type de la liste cible)
	- #6 Créer un template personnalisé en ignorant les colonnes suivantes (dans l'onglet 'Metadata'):
		- Date Slug
		- Title Slug
		- Content Association Key
		- Item Language
	Le nom de ce template devra être mis dans la variable "$DSP_CUSTOM_PropertyTemplateName" dans le fichier Tokens.Docs.Custom.ps1

	Cette procédure permet de ne pas écraser la valeur du "Content Association Key" lors de la copie par les variations.

- Le template "DynamitTemplate" par défaut cotient les paramètres suivants:

- DynamiteTitleSlug = Ignore
- DynamiteDateSlug = Ignore
- DynamiteContentAssociationKey = Ignore
- DynamiteItemLanguage = Ignore
- ItemGroupId = Ignore (Champ de liaison interne utilisé par les variations).

