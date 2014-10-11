
document.write('<DIV id="PendingMessage" class="Load">&nbsp;</DIV>');

document.onreadystatechange = function () {
    if (document.readyState == "complete") {
        HiddenLoading();
    }
}
//function document.onreadystatechange()
//{	
//    if (document.readyState == "complete") 
//    {
//        HiddenLoading();
//    }
//}

function ShowLoading() {
    //$('PendingMessage').style.display = "block";
    $('PendingMessage').style.display = "none";
}
function HiddenLoading() {
    $('PendingMessage').style.display = "none";
}



var _stylePath = null//图片所在的路径
var _curentFrame = null;//当前框架的ID
var _curentUrl = null; //当前框架的地址
var _isShowCloseBtn = null;



/*-------------------------------------------------------------------------------
功能：类似winForm的基于javascript的TabControl效果
参数：str:消息体
调用方法
var myTab = new HTabControl(_skinId,true);
document.write(myTab.init());

不刷新
top.myTab.Cts('标题','default1.aspx')
刷新
top.myTab.Cts('标题','default1.aspx',true)
-------------------------------------------------------------------------------*/


function HTabControl(tabSkinId, isShowCloseBtn) {
    //this.tabSkinId = tabSkinId;
    _isShowCloseBtn = isShowCloseBtn;
    //_stylePath = _path + "UI/Skin/Tab"+ tabSkinId +"/";
    _stylePath = "Skin/Tab" + tabSkinId + "/";

    this.init = function () {
        loadStyle(this.tabSkinId, "tab.css");
        return "<div id='tabContextMenu' class='ContextMenu' onclick='HiddenDiv(this.id)'>" +
        "<table border='0' cellpadding='0' cellspacing='0'>" +
        "<tr><td class='rightMenuItem1' onclick='window.open(_curentUrl)'>新开</td></tr>" +
        "<tr><td class='rightMenuItem2' onclick='fullOpen(_curentUrl)'>全屏打开</td></tr>" +
        "<tr><td class='rightMenuItem3' onclick=GetIframe('F_'+_curentFrame).document.location.reload();>刷新</td></tr> " +
        "</table>" +
        "</div>" +

        "<table width='100%' height='100%' border='0' cellspacing='0' cellpadding='0'>" +
        "<tr>" +
        "<td style='height:21px' valign='bottom'>" +
        "<table height='100%' id='tabFrameTitle' border='0' cellspacing='0' cellpadding='0'>" +
        "<tr>" +
        "<td valign='bottom'></td>" +
        "</tr>" +
        "</table>" +
        "</td>" +
        "</tr>" +
        "<tr>" +
        "<td class='tabpage' valign='top' id='tdFramePane'></td>" +
        "</tr>" +
        "</table>";
    }

    //如果不存在页面就创建，如果存在就聚焦
    this.Cts = function (title, url, isRef) {
        var objTitle = $("tabFrameTitle");
        var objIframe = $("tdFramePane");

        //如果没有该页建立该页 
        if (!$(title)) {
            ShowLoading();
            CreateTitle(objTitle, title);
            if (isRef == true) {
                CreateIframe(objIframe, title, 'auto');
            }
            else {
                CreateIframe(objIframe, title, 'auto', url);
            }

            if (objTitle.offsetHeight > 25) {
                alert("您打开了太多的窗口，可能导致页面局部变形。建议关闭一部分窗口");
            }
            FoucsPage(title, url, isRef);//by dh
        }



        //聚焦到该页
        FoucsPage(title, url, isRef);
        CollectGarbage();//清理浏览器内存 
        _curentUrl = url;
        HiddenDiv('tabContextMenu');
    }
}


function loadStyle(skinId, cssName) {
    var head = document.getElementsByTagName('head').item(0);
    css = document.createElement('link');
    css.href = _stylePath + cssName;
    css.rel = 'stylesheet';
    css.type = 'text/css';
    css.id = 'loadCss';
    head.appendChild(css);
}


//------------------------------主框架的TabControl效果-------------------------------


//添加标题
function CreateTitle(obj, title) {

    //建立一个一行三列的表格用于tab的标题头

    var titleTable = document.createElement("table");
    titleTable.setAttribute("border", "0");
    titleTable.setAttribute("cellPadding", "0");
    titleTable.setAttribute("cellSpacing", "0");

    var titleBody = document.createElement("tbody");

    var titleRow = document.createElement("tr");

    //建立第一列
    var tdLeft = document.createElement("td");
    tdLeft.className = "tabTitleFoucs_l";


    //建立第二列   
    var tdMid = document.createElement("td");//作为标题显示
    tdMid.innerHTML = title;
    tdMid.className = "tabTitleFoucs_m";
    tdMid.title = "双击刷新该页";
    tdMid.onselectstart = function () { return false };
    tdMid.oncontextmenu = function () {
        e = window.event || e; e = e.srcElement || e.target;
        if ("It_" + _curentFrame != e.parentElement.parentElement.parentElement.id) return false;
        obj = $("tabContextMenu");
        with (obj) {
            style.pixelLeft = event.x - 3;
            style.pixelTop = event.y - 3;
            style.visibility = "visible";
        }
        return false;
    }


    //建立第三列   
    var tdClose = document.createElement("td");//作为关闭按纽的容器
    tdClose.className = "tabTitleFoucs_m";
    tdClose.style.width = "11px";

    //建立关闭按纽
    if (_isShowCloseBtn) {
        CreateCloseBtn(tdClose, title);
    }

    //建立第四列  
    var tdRight = document.createElement("td");
    tdRight.className = "tabTitleFoucs_r";

    //把列加到行
    titleRow.appendChild(tdLeft);
    titleRow.appendChild(tdMid);
    titleRow.appendChild(tdClose);
    titleRow.appendChild(tdRight);

    //把行加到tbody
    titleBody.appendChild(titleRow);

    //把tbody加到表格
    titleTable.appendChild(titleBody);
    titleTable.id = "It_" + title;
    titleTable.onclick = function () {
        FoucsPage(title);

    };
    titleTable.ondblclick = function () {
        GetIframe("F_" + _curentFrame).document.location.reload();
    }

    //在主表格上建立一个列
    var mainTd = document.createElement("td");
    mainTd.id = title;
    mainTd.setAttribute("height", "21");
    mainTd.appendChild(titleTable);


    //把列加到主表格
    obj.rows[0].appendChild(mainTd);

}

//创建新的Iframe
function CreateIframe(obj, title, canScoll, url) {
    var iFrame = document.createElement("iframe");
    iFrame.id = "F_" + title;
    iFrame.name = "F_" + title;
    if (url != null) iFrame.src = url;
    iFrame.frameBorder = "0";
    iFrame.scrolling = canScoll;
    iFrame.className = "Frame";
    iFrame.style.width = "100%";
    iFrame.style.height = "100%";
    //iFrame.onreadystatechange = function()
    //{
    //    if (iFrame.document.readyState == "complete") 
    //    {
    //        HiddenLoading();
    //    }
    //} by dh 注释
    obj.appendChild(iFrame);
    GetIframe("F_" + title).window.document.onclick = function () {
        HiddenDiv('tabContextMenu');
    }
    //    GetIframe("F_"+title).window.document.onreadystatechange = function()
    //    {
    //        if(GetIframe("F_"+title).window.document.readyState == "complete")
    //        {
    //            HiddenLoading();
    //        }
    //    }
}
//获取Iframe
function GetIframe(id) {
    return document.frames[id];
}

//创建关闭按纽
function CreateCloseBtn(parent, id) {
    var closeBtn = new Image();
    closeBtn.id = "btn" + id;
    closeBtn.src = _stylePath + "tab_close.jpg";
    closeBtn.style.cursor = "pointer";
    closeBtn.onclick = function (e) {
        if (FindOtherFrameId(id) != null) {
            var title = FindOtherFrameId(id);
            //FoucsPage(title);
            CloseTitle(id);
            CloseIframe("F_" + id);
            HiddenLoading();
            FoucsPage(title);
            if (e) //停止事件冒泡
                e.stopPropagation();
            else
                window.event.cancelBubble = true;
        }
        else {
            alert("必须保留一个标签");
        }
    }
    parent.appendChild(closeBtn);
}

function CloseCurPage() {
    $("btn" + _curentFrame).click();
    CollectGarbage();
}


//找“相邻”标题所对应的框架的Id
function FindOtherFrameId(id) {
    var lastIframeId = null;
    var objTitle = $("tabFrameTitle");
    var cellCount = objTitle.rows[0].cells.length;
    var currentCellIndex = 0;
    for (var i = 0 ; i < cellCount ; ++i) {
        if (objTitle.rows[0].cells[i].id == id) {
            currentCellIndex = i;
        }
    }
    if (cellCount == 2) {
        return null;
    }
    if (currentCellIndex == 1 && currentCellIndex + 1 <= cellCount) {
        lastIframeId = objTitle.rows[0].cells[currentCellIndex + 1].id;
    }
    else {
        lastIframeId = objTitle.rows[0].cells[currentCellIndex - 1].id;
    }
    if (lastIframeId == "") lastIframeId = null;
    return lastIframeId;
}

//关闭标题
function CloseTitle(id) {
    if (id != null) {
        var objTitle = $("tabFrameTitle");
        for (var i = 0 ; i < objTitle.rows[0].cells.length ; ++i) {
            if (objTitle.rows[0].cells[i].id == id) {
                if (GetBrowser() == "IE") {
                    objTitle.rows[0].cells[i].removeNode(true);
                }
                else {
                    node = objTitle.rows[0].cells[i];
                    node.parentNode.removeChild(node);
                }
            }
        }
    }
}

//关闭框架
function CloseIframe(id) {
    if (GetBrowser() == "IE") {
        var obj = $(id);
        obj.removeNode(true)
    }
    else {
        node = $(id);
        node.parentNode.removeChild(node);
    }
}

//聚焦到对应的标题
function FoucsPage(id, url, isRef) {
    if (id == null) {
        _curentFrame = null;
        return;
    }
    if (_curentFrame == id) return;
    _curentFrame = id;
    ShowTitle(id);
    ShowIframe(id, url, isRef);
}

//显示标题及相关样式
function ShowTitle(id) {
    var objTitle = $("tabFrameTitle");
    for (var i = 0 ; i < objTitle.rows[0].cells.length ; ++i) {
        curId = objTitle.rows[0].cells[i].id;
        if (curId != "") {
            $("It_" + curId).rows[0].cells[0].className = "tabTitleUnFoucs_l";
            $("It_" + curId).rows[0].cells[1].className = "tabTitleUnFoucs_m";
            $("It_" + curId).rows[0].cells[2].className = "tabTitleUnFoucs_m";
            $("It_" + curId).rows[0].cells[3].className = "tabTitleUnFoucs_r";
        }
    }
    if ($("It_" + id) != null) {//by dh
        $("It_" + id).rows[0].cells[0].className = "tabTitleFoucs_l";
        $("It_" + id).rows[0].cells[1].className = "tabTitleFoucs_m";
        $("It_" + id).rows[0].cells[2].className = "tabTitleFoucs_m";
        $("It_" + id).rows[0].cells[3].className = "tabTitleFoucs_r";
    }
}

//显示指定的Iframe
function ShowIframe(id, url, isRef) {
    var objIframe = $("tdFramePane");
    for (i = 0; i < objIframe.childNodes.length; i++) {
        if (objIframe.childNodes[i].id == "F_" + id) {
            objIframe.childNodes[i].style.display = '';
            if (isRef == true) {
                objIframe.childNodes[i].src = url;
            }
        }
        else {
            objIframe.childNodes[i].style.display = 'none';
        }
    }
}

function GetBrowser() {
    if (document.all)
        return "IE";
    if (document.layers)
        return "NS";
    return "OTHER";
}

//-->