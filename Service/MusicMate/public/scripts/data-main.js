require.config({
    baseUrl: "../",
    paths: {
        "jquery": "libs/jquery-2.1.1.min",
        "jqueryui": "libs/jquery-ui.1.11.2.min",
        "css": "libs/require.css.min",
        "react": "libs/react.0.12.2",
        "_": "libs/lodash.css.min",
    },
    shim : {
        "jqueryui": ["jquery", "css!/css?f=jqueryui/jquery-ui.min,jqueryui/jquery-ui.structure.min,jqueryui/jquery-ui.theme.min"],
        "react" : []
    },
    deps : ["jquery","react"]
});

// jquery dom ready plugin
define("ready", ["jquery"], { load: function (name, parentRequire, onload, config) { $(function () { onload(); }); } });

define("widgets", [
    'scripts/build/player'
])

require(["jquery","widgets","ready!"], function () {
    React.render(document.querySelector("body"));
});