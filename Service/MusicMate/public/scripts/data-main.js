require.config({
    baseUrl: "../",
    paths: {
        "jquery": "libs/jquery-2.1.1.min",
        "jqueryui": "libs/jquery-ui.1.11.2.min",
        "jstree": "libs/jstree.min",
        "css": "libs/require.css.min",
    },
    shim : {
        "jstree": ["jquery", "css!/css?f=jstree/style.min"],
        "jqueryui": ["jquery", "css!/css?f=jqueryui/jquery-ui.min,jqueryui/jquery-ui.structure.min,jqueryui/jquery-ui.theme.min"],
    },
    deps : ["jquery"]
});

// jquery dom ready plugin
define("ready", ["jquery"], { load: function (name, parentRequire, onload, config) { $(function () { onload(); }); } });

require(["jquery","ready!"], function () {
    $("#sync").on("click", function () {
        require(["jqueryui", "jstree"], function () {
            $("#sync-modal").dialog({
                modal: true,
                title : "Select directories to sync"
            });
        });
    });
});