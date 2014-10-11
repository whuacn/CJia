var _path = "/CJia.Health.Web/"; //如果网站不在根目录下 而是在虚拟目录下 请在这里写下虚拟目录的名称。
var _skinId = getCookie("_skinId") ? getCookie("_skinId"):"1";

function loadSkin(skinId)
{
    writeCookie("_skinId",skinId);
    top.window.location.reload();
}

function $(id)
{
    return document.getElementById(id);
}
//51/a/s/p/x/
function loadCss(skinId,cssName)
{
    var head = document.getElementsByTagName('head').item(0);
    css = document.createElement('link');
    css.href = "Skin/Skin" + skinId + "/"+cssName;
    css.rel = 'stylesheet';
    css.type = 'text/css';
    css.id = 'loadCss';
    head.appendChild(css);
}

function loadJs(file)
{
    var scriptTag = document.getElementById('loadScript');
    var head = document.getElementsByTagName('head').item(0);
    if(scriptTag) head.removeChild(scriptTag);
    script = document.createElement('script');
    script.src = "../js/mi_"+file+".js";
    script.type = 'text/javascript';
    script.id = 'loadScript';
    head.appendChild(script);
}

function setCookie(sKey, sValue, sDomain, sPath, sExpires, blSecure)
{
	var sCookieStr = sKey + "=" + sValue + ";";

	if (sDomain)	sCookieStr += " DOMAIN=" + sDomain + ";";
	if (sPath)		sCookieStr += " PATH=" + sPath + ";";
	if (sExpires)	sCookieStr += " EXPIRES=" + sExpires + ";";
	if (blSecure)	sCookieStr += " SECURE";
	
	document.cookie = sCookieStr;
}

function writeCookie(key,value)
{
    var sExpires=new Date();
    sExpires.setTime(sExpires.getTime()+24*60*60*1000*365);
    setCookie(key,value,"","",sExpires.toGMTString(),""); 
    if(getCookie(key) == null)
    {
        alert("您的浏览器安全设置过高,不支持Cookie,请重新设置浏览器的。");
    }
}
	
function getCookie(sKey)
{
	var sCookie = document.cookie;
	if( !sCookie ) return null;
	
	var sTag = sKey + "=";
		
	var iBegin = sCookie.indexOf(sTag);
	if (iBegin < 0)	return null;
	
	iBegin += sTag.length;
	
	var iEnd = sCookie.indexOf(";", iBegin);
	if (iEnd < 0)	iEnd = sCookie.length;
	
	return sCookie.substring(iBegin, iEnd);
}

function delCookie(sKey) 
{
	var tNow = new Date();
	setCookie(sKey, "", null, null, tNow.toGMTString(), null);
}

function fullOpen(url)
{
    HeightValue=screen.height;
    WidthValue=screen.width;
    newwin=window.open(url,"","toolbar=0,location=0,directories=0,status=1,menubar=0,resizable=1,left=0,top=0,scrollbars=yes")
    if(newwin == null)
    {
        alert("系统提示: 您的浏览器阻止了一个弹出窗口");
        return;
    }
    newwin.moveTo(-3,-3);
    newwin.resizeTo(WidthValue+6,HeightValue-23);
}

function ShowDiv(id)
{
    $(id).style.visibility = "visible";
}
function HiddenDiv(id)
{
    $(id).style.visibility = "hidden";
}


