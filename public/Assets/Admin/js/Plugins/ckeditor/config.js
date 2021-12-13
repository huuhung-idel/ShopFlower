/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';

    config.syntaxhightlight_lang = 'csharp';
    config.syntaxhightlight_hiheControls = true;
 
    config.language = 'vi';
    config.filebrowserBrowserUrl = '/Assets/Admin/js/Plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowserUrl = '/Assets/Admin/js/Plugins/ckfinder.html?Type=Image';
    config.filebrowserFlashBrowserUrl = '/Assets/Admin/js/Plugins/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Assets/Admin/js/Plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=File';
    config.filebrowserImageUploadUrl = '/Data';
    config.filebrowserFlashUploadUrl = '/Assets/Admin/js/Plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/Assets/Admin/js/Plugins/ckfinder/');
};
