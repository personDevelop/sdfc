// JQuery URL Parser
// Written by Mark Perkins, mark@allmarkedup.com
// License: http://unlicense.org/ (i.e. do what you want with it!)

jQuery.url = function () {
    var segments = {};

    var parsed = {};

    /**
    * Options object. Only the URI and strictMode values can be changed via the setters below.
    */
    var options = {

        url: window.location, // default URI is the page in which the script is running

        strictMode: false, // 'loose' parsing by default

        key: ["source", "protocol", "authority", "userInfo", "user", "password", "host", "port", "relative", "path", "directory", "file", "query", "anchor"], // keys available to query 

        q: {
            name: "queryKey",
            parser: /(?:^|&)([^&=]*)=?([^&]*)/g
        },

        parser: {

            strict: /^(?:([^:\/?#]+):)?(?:\/\/((?:(([^:@]*):?([^:@]*))?@)?([^:\/?#]*)(?::(\d*))?))?((((?:[^?#\/]*\/)*)([^?#]*))(?:\?([^#]*))?(?:#(.*))?)/,  //less intuitive, more accurate to the specs
            loose: /^(?:(?![^:@]+:[^:@\/]*@)([^:\/?#.]+):)?(?:\/\/)?((?:(([^:@]*):?([^:@]*))?@)?([^:\/?#]*)(?::(\d*))?)(((\/(?:[^?#](?![^?#\/]*\.[^?#\/.]+(?:[?#]|$)))*\/?)?([^?#\/]*))(?:\?([^#]*))?(?:#(.*))?)/ // more intuitive, fails on relative paths and deviates from specs
        }

    };

    /**
    * Deals with the parsing of the URI according to the regex above.
    * Written by Steven Levithan - see credits at top.
    */
    var parseUri = function () {
        // if(window.frameElement==null && jQuery.browser.msie && j
        // str = decodeURI(options.url);
        var str;
        if ($.browser.webkit) {
            str = decodeURI(options.url);
        } else {
            str = unescape(options.url);
        }
        var m = options.parser[options.strictMode ? "strict" : "loose"].exec(str);
        var uri = {};
        //edit by lhy 看不懂parser 正则表达式，如果含有@等会出错，直接在此处增加重新复制的功能。
        if (!m[12]) m[12] = str.substr(str.indexOf('?') + 1);
        //end edit by lhy 看不懂parser 正则表达式，如果含有@等会出错，直接在此处增加重新复制的功能。
        var i = 14;

        while (i--) {
            uri[options.key[i]] = m[i] || "";
        }

        uri[options.q.name] = {};
        uri[options.key[12]].replace(options.q.parser, function ($0, $1, $2) {
            if ($1) {
                uri[options.q.name][$1] = $2;
            }
        });

        return uri;
    };

    /**
    * Returns the value of the passed in key from the parsed URI.
    * 
    * @param string key The key whose value is required
    */
    var key = function (key) {
        if (jQuery.isEmptyObject(parsed)) {
            setUp(); // if the URI has not been parsed yet then do this first...	
        }
        if (key == "base") {
            if (parsed.port !== null && parsed.port !== "") {
                return parsed.protocol + "://" + parsed.host + ":" + parsed.port + "/";
            }
            else {
                return parsed.protocol + "://" + parsed.host + "/";
            }
        }

        return (parsed[key] === "") ? null : parsed[key];
    };

    /**
    * Returns the value of the required query string parameter.
    * 
    * @param string item The parameter whose value is required
    */
    var param = function (item, url) {
        url = url || window.location;
        options.url = url;
        setUp();
        /*每次都重新加载，否则多iframe会出错，by lhy 20140304
        if (jQuery.isEmptyObject(parsed)) {
        setUp(); // if the URI has not been parsed yet then do this first...	
        }*/
        return (parsed.queryKey[item] === null) ? null : parsed.queryKey[item];
    };

    /**
    * 'Constructor' (not really!) function.
    *  Called whenever the URI changes to kick off re-parsing of the URI and splitting it up into segments. 
    */
    var setUp = function () {
        parsed = parseUri();
        getSegments();
    };

    /**
    * Splits up the body of the URI into segments (i.e. sections delimited by '/')
    */
    var getSegments = function () {
        var p = parsed.path;
        segments = []; // clear out segments array
        segments = parsed.path.length == 1 ? {} : (p.charAt(p.length - 1) == "/" ? p.substring(1, p.length - 1) : path = p.substring(1)).split("/");
    };

    return {

        /**
        * Sets the parsing mode - either strict or loose. Set to loose by default.
        *
        * @param string mode The mode to set the parser to. Anything apart from a value of 'strict' will set it to loose!
        */
        setMode: function (mode) {
            options.strictMode = mode == "strict" ? true : false;
            return this;
        },

        /**
        * Sets URI to parse if you don't want to to parse the current page's URI.
        * Calling the function with no value for newUri resets it to the current page's URI.
        *
        * @param string newUri The URI to parse.
        */
        /* 不能使用 edit by lhy 如果多iframe时，缓存后会出现url混乱 edit by lhy 20140304
        setUrl: function (newUri) {
        options.url = newUri === undefined ? window.location : newUri;
        setUp();
        return this;
        },*/

        /**
        * Returns the value of the specified URI segment. Segments are numbered from 1 to the number of segments.
        * For example the URI http://test.com/about/company/ segment(1) would return 'about'.
        *
        * If no integer is passed into the function it returns the number of segments in the URI.
        *
        * @param int pos The position of the segment to return. Can be empty.
        */
        segment: function (pos) {
            if (jQuery.isEmptyObject(parsed)) {
                setUp(); // if the URI has not been parsed yet then do this first...	
            }
            if (pos === undefined) {
                return segments.length;
            }
            return (segments[pos] === "" || segments[pos] === undefined) ? null : segments[pos];
        },

        attr: key, // provides public access to private 'key' function - see above

        param: param // provides public access to private 'param' function - see above

    };

} ();



 