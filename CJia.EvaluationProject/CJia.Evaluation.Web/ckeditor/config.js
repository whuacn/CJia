/**
 * @license Copyright (c) 2003-2014, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    //config.uiColor = '#AADC6E';//�༭����ɫ
    config.language = 'zh-cn';//����
    //config.width = '1000px';
    config.font_names = '����;����_GB2312;������;����;����;��Բ;΢���ź�;Arial;Comic Sans MS;Courier New;Tahoma;Times New Roman;Verdana';
    var PublicPath = "/";
    config.filebrowserBrowseUrl = PublicPath + 'Ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = PublicPath + 'Ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = PublicPath + 'Ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = PublicPath + 'Ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = PublicPath + 'Ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = PublicPath + 'Ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
};
