// Ensure presence of Dynamite Portal namespace
window.GSoft = window.GSoft || {};
window.GSoft.Dynamite = window.GSoft.Dynamite || {};
window.GSoft.Dynamite.Portal = window.GSoft.Dynamite.Portal || {};

// ====================
// ChildNodes Module
// ====================
(function (ChildNodes, $, undefined) {

    // Private variables

    // Public properties
    ChildNodes.ViewModels = [];

    // Public Methods
    ChildNodes.initialize = function (childNodesParams) {
        $(document).ready(function () {
            var vm = new ChildNodesViewModel();
            vm.Nodes = childNodesParams.RawChildNodes[0].ChildNodes;
            ChildNodes.ViewModels.push(vm);

            var parentElement = $("#" + childNodesParams.ParentElementId)[0];
            ko.applyBindings(vm, parentElement);
        });
    };

    // Main menu control view model definition    
    function ChildNodesViewModel() {
        var self = this;
        self.Nodes = ko.observableArray();
    }

    // Main menu control view model definition    
    function ChildNodeViewModel() {
        var self = this;
        self.Title = ko.observable("");
        self.Link = ko.observable("");
    }

    // Private Methods

}(GSoft.Dynamite.Portal.ChildNodes = GSoft.Dynamite.Portal.ChildNodes || {}, jq110));

// ====================
// Navigation Module
// ====================
(function (SideMenu, $, undefined) {

    // Private variables

    // Public properties
    SideMenu.ViewModels = [];
    SideMenu.RawChildNodes = null;
    SideMenu.SearchPages = null;

    // Public Methods
    SideMenu.initialize = function (sideMenuParams) {
        $(document).ready(function () {
            var vm = new NodesViewModel();
            vm.ParentTitle = sideMenuParams.RawChildNodes[0].Title;
            vm.ParentUrl = sideMenuParams.RawChildNodes[0].Url;
            var pages, navigation;

            //Gets only nodes in JSON
            var nodes = sideMenuParams.RawChildNodes[0].ChildNodes.filter(function (node) {
                return node.Id != "00000000-0000-0000-0000-000000000000";
            });

            if (sideMenuParams.SearchPages == 'True') {
                pages = sideMenuParams.RawChildNodes[0].ChildNodes.filter(function (node) {
                    return node.Id == "00000000-0000-0000-0000-000000000000";
                });
                navigation = nodes.concat(pages);

            } else {
                navigation = nodes;
            }

            vm.Nodes = navigation;
            SideMenu.ViewModels.push(vm);

            var parentElement = $("#" + sideMenuParams.ParentElementId)[0];

            ko.applyBindings(vm, parentElement);
        });
    };

    //Sorting pages and leafs
    function Ordering(a, b) {
        if (a.Id < b.Id) {
            return 1;
        }
        if (a.Id > b.Id) {
            return -1;
        }
        return 0;
    }

    // Main menu control view model definition    
    function NodesViewModel() {
        var self = this;
        self.ParentTitle = ko.observable("");
        self.ParentUrl = ko.observable("");
        self.Nodes = ko.observableArray();
        //self.Leafs = ko.observableArray();
    }

    // Main menu control view model definition    
    function NodeViewModel() {
        var self = this;
        self.Title = ko.observable("");
        self.Link = ko.observable("");
    }

    // Private Methods

}(GSoft.Dynamite.Portal.SideMenu = GSoft.Dynamite.Portal.SideMenu || {}, jq110));

