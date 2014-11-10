(function (MainMenu, $, undefined) {

    // Public properties    
    MainMenu.ViewModel = null;
    MainMenu.HideDelay = 600;
    MainMenu.ShowDelay = 300;
    MainMenu.HideDelayTimeout = null;
    MainMenu.ShowDelayTimeout = null;
    MainMenu.Level4Max = 6;

    // Public Methods
    MainMenu.initialize = function (data, numberOfFlatLevel) {
        $(document).ready(function () {
            MainMenu.ViewModel = new MainMenuViewModel(data, numberOfFlatLevel);
            ko.applyBindings(MainMenu.ViewModel, $("#main-menu")[0]);
                
            // Fix menu padding
            $(window).bind("load", function () {
                var level2 = $("ul.main-menu-level-2")
                var space = level2.width() - 1;
                var taken = 0;

                _.each(level2.children("li"), function (li) {
                    taken += ($(li)[0].getBoundingClientRect().width);
                })

                var padding = (space - taken) / (level2.children("li").length * 2);
                level2.find("a.main-menu-level-2").css("padding-left", padding + "px").css("padding-right", padding + "px");

                $("li.main-menu-level-1").mouseenter(MainMenu.MouseEnterTab);
                $("div.main-menu-level-2").mouseenter(MainMenu.MouseEnterMenu);
                $("ul.main-menu-level-2").mouseleave(MainMenu.MouseLeave);
                $("li.main-menu-level-1").mouseleave(MainMenu.MouseLeave);

                // Click outside the menu : instantly hide it.
                $("html").click(function () {
                    $("div.main-menu-level-2").hide();
                    window.clearTimeout(MainMenu.HideDelayTimeout);
                });

                // Except for the menu itself
                $("#main-menu").click(function (event) {
                    event.stopPropagation();
                });

                // Floating menu top offset
                $("div.main-menu-level-3").css("top", level2.outerHeight() + "px");

                // Set Arrow Left offset
                //_.each($("li.main-menu-level-2"), function (item) {
                //    var arrow = $(item).next().find(".menu-arrow");
                //    var left = $(item).offset().left - $(item).parent().offset().left + ($(item).width() / 2 - 5);
                //    arrow.css("left", (left) + "px");
                //});
            });
        });
    };

    MainMenu.MouseEnterTab = function (event) {
        window.clearTimeout(MainMenu.HideDelayTimeout);

        MainMenu.ShowDelayTimeout = window.setTimeout(function () {
            // Cancel differ hide
            window.clearTimeout(MainMenu.HideDelayTimeout);

            // Hide every menu
            $("div.main-menu-level-2").hide();

            // Show the good one
            $(event.currentTarget).next().show();
        }, MainMenu.ShowDelay);

    };

    MainMenu.MouseEnterMenu = function (event) {
        window.clearTimeout(MainMenu.HideDelayTimeout);
        window.clearTimeout(MainMenu.ShowDelayTimeout);
    };

    MainMenu.MouseLeave = function (event) {
        window.clearTimeout(MainMenu.ShowDelayTimeout);
        MainMenu.HideDelayTimeout = window.setTimeout(function () {
            $("div.main-menu-level-3").hide();
        }, MainMenu.HideDelay);
    };

    function MainMenuViewModel(data) {
        var self = this;
        var level = 1;

        self.Nodes = ko.observableArray();

        _.each(data, function (node) {
            self.Nodes.push(new NodeViewModel(node.Title, node.Url, node.ChildNodes, level, data.length, node.IsCurrentNode, node.IsNodeInCurrentBranch));
        });

        self.CurrentNodeChildren = ko.computed(function () {

            var currentNode = _.find(self.Nodes(), function (node) {
                return node.IsNodeInCurrentBranch();
            })

            if (currentNode) {
                return currentNode.ChildNodes();
            }

            return [];
        });
    }

    function NodeViewModel(title, url, childNodes, level, nbUncles, isCurrentNode, isNodeInCurrentBranch) {
        var self = this;

        self.Title = ko.observable(title);
        self.Url = ko.observable(url);
        self.ChildNodes = ko.observableArray();
        self.ChildNodes1 = ko.observableArray();
        self.ChildNodes2 = ko.observableArray();
        self.ChildNodes3 = ko.observableArray();
        self.ChildNodes4 = ko.observableArray();
        self.Level = ko.observable(level);
        self.NbUncles = ko.observable(nbUncles);
        self.IsCurrentNode = ko.observable(isCurrentNode);
        self.IsNodeInCurrentBranch = ko.observable(isNodeInCurrentBranch);

        self.LevelClass = ko.computed(function () {
            var level = "main-menu-level-" + self.Level();
            var isCurrentNode = self.IsCurrentNode() ? "current-node" : "";
            var isNodeInCurrentBranch = self.IsNodeInCurrentBranch() ? "node-in-current-branch" : "";
            var is2Columns = self.ChildNodes2().length > 0 ? "main-menu-2-col" : "";
            return [level, isCurrentNode, isNodeInCurrentBranch, is2Columns].join(" ");
        });

        self.NextLevelClass = ko.computed(function () {
            var is2Columns = self.ChildNodes2().length > 0 ? "main-menu-2-col" : "";
            var nextLevel = "main-menu-level-" + (self.Level() + 1);
            return [nextLevel, is2Columns].join(" ");
        });

        var count = 0;
        var uncles = childNodes.length;
        if (self.Level() === 3) {
            uncles = self.NbUncles();
        }

        _.each(childNodes, function (node) {

            self.ChildNodes.push(new NodeViewModel(node.Title, node.Url, node.ChildNodes, self.Level() + 1, uncles));

            if (count < MainMenu.Level4Max) {
                self.ChildNodes1.push(new NodeViewModel(node.Title, node.Url, node.ChildNodes, self.Level() + 1, uncles));
            }
            else if (self.NbUncles() < 3 && count < MainMenu.Level4Max * 2) {
                self.ChildNodes2.push(new NodeViewModel(node.Title, node.Url, node.ChildNodes, self.Level() + 1, uncles));
            }
            else if (self.NbUncles() === 1 && count < MainMenu.Level4Max * 3) {
                self.ChildNodes3.push(new NodeViewModel(node.Title, node.Url, node.ChildNodes, self.Level() + 1, uncles));
            }
            else if (self.NbUncles() === 1 && count < MainMenu.Level4Max * 4) {
                self.ChildNodes4.push(new NodeViewModel(node.Title, node.Url, node.ChildNodes, self.Level() + 1, uncles));
            }

            count++;
        });

        if (count >= MainMenu.Level4Max && self.NbUncles() >= 3) {
            // Add "Tout voir" on the first column
            self.ChildNodes1.push(new NodeViewModel("voir plus", self.Url(), [], 99));
        }
        else if (count >= (MainMenu.Level4Max * 2) && self.NbUncles() < 3) {
            // Add "Tout voir" on the second column
            self.ChildNodes2.push(new NodeViewModel("voir plus", self.Url(), [], 99));
        }
        else if (count >= (MainMenu.Level4Max * 4) && self.NbUncles() === 1) {
            // Add "Tout voir" on the fourth column
            self.ChildNodes4.push(new NodeViewModel("voir plus", self.Url(), [], 99));
        }
    }

}(Portal.MainMenu = Portal.MainMenu || {}, jq110));