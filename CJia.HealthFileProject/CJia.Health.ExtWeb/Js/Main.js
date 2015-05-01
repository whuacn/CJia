function onReady() {

    //初始化菜单
    var tree_MBasic = Ext.getCmp(IDS.tree_MBasic);
    var tree_MBusiness = Ext.getCmp(IDS.tree_MBusiness);
    var tree_MArticle = Ext.getCmp(IDS.tree_MArticle);
    var tree_MCenter = Ext.getCmp(IDS.tree_MCenter);
    //var tree_MInfo = Ext.getCmp(IDS.tree_MInfo);
    //var tree_MGoods = Ext.getCmp(IDS.tree_MGoods);
    //var tree_MDept = Ext.getCmp(IDS.tree_MDept);
    //var tree_MUser = Ext.getCmp(IDS.tree_MUser);
    //var tree_MSystem = Ext.getCmp(IDS.tree_MSystem);
    //var tree_Suppter = Ext.getCmp(IDS.tree_Suppter);
    var tabs_Main = Ext.getCmp(IDS.tabs_Main);

    IniTree(tree_MBasic);
    IniTree(tree_MBusiness);
    IniTree(tree_MArticle);
    IniTree(tree_MCenter);
    //IniTree(tree_MInfo);
    //IniTree(tree_MGoods);
    //IniTree(tree_MDept);
    //IniTree(tree_MUser);
    //IniTree(tree_MSystem);
    //IniTree(tree_Suppter);

    function IniTree(tree) {
        tree.on('click', function (node, event) {
            if (node.isLeaf()) {
                event.stopEvent();
                var href = node.attributes.href;
                window.location.href = '#' + href;
                addTab(node);
            }
        });
    }

    // 动态添加一个标签页
    function addTab(node) {
        var href = node.attributes.href;

        var refreshButton = new Ext.Button({
            text: '刷新窗口',
            type: "button",
            iconCls: "icon-arrowrefresh",
            listeners: {
                click: function (button, e) {
                    Ext.DomQuery.selectNode('iframe', button.ownerCt.ownerCt.getEl().dom).contentWindow.location.replace(href);
                    e.stopEvent();
                }
            }
        });

        var openNewWindowButton = new Ext.Button({
            text: '新页面打开',
            type: "button",
            iconCls: "icon-tabpanel",
            listeners: {
                click: function (button, e) {
                    window.open(href, "_blank");
                    e.stopEvent();
                }
            }
        });

        var iconCls = node.attributes['icon'].replace(/[^.]+\//, '').replace('.png', '');
        // 动态添加一个带工具栏的标签页
        var tabId = 'dynamic_tab' + node.id.replace('__', '-');
        var currentTab = tabs_Main.getTab(tabId);
        if (!currentTab) {
            tabs_Main.addTab({
                'id': tabId,
                'url': href,
                'title': node.text,
                'closable': true,
                'bodyStyle': 'padding:0px;',
                'iconCls': "icon-" + iconCls,
                'tbar': new Ext.Toolbar({
                    items: ['->', refreshButton, '-', openNewWindowButton]
                })
            });
        } else {
            tabs_Main.setActiveTab(currentTab);
        }
    }

    tabs_Main.on('tabchange', function (tabStrip, tab) {
        if (tab.url) {
            window.location.href = '#' + tab.url;
        } else {
            window.location.href = '#';
        }
    });

    //加载当前页
    var HASH = window.location.hash.substr(1);
    var FOUND = false;
    if (HASH) {
        if (!FOUND) {
            findTab(tree_MBasic.getRootNode());
        }
        if (!FOUND) {
            findTab(tree_MBusiness.getRootNode());
        }
        if (!FOUND) {
            findTab(tree_MArticle.getRootNode());
        }
        if (!FOUND) {
            findTab(tree_MCenter.getRootNode());
        }
        //if (!FOUND) {
        //    findTab(tree_MInfo.getRootNode());
        //}
        //if (!FOUND) {
        //    findTab(tree_MGoods.getRootNode());
        //}
        //if (!FOUND) {
        //    findTab(tree_MDept.getRootNode());
        //}
        //if (!FOUND) {
        //    findTab(tree_MUser.getRootNode());
        //}
        //if (!FOUND) {
        //    findTab(tree_MSystem.getRootNode());
        //}
        //if (!FOUND) {
        //    findTab(tree_Suppter.getRootNode());
        //}
    }
    function findTab(node) {
        var i, currentNode, nodes;
        if (!FOUND && node.hasChildNodes()) {
            nodes = node.childNodes;
            for (i = 0; i < nodes.length; i++) {
                currentNode = nodes[i];
                if (currentNode.isLeaf()) {
                    if (currentNode.attributes.href === HASH) {
                        addTab(currentNode);
                        FOUND = true;
                        return;
                    }
                } else {
                    findTab(currentNode);
                }
            }
        }
    }
}