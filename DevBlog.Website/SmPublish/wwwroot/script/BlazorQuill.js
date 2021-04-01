(function () {
    window.QuillFunctions = {
        quillObj: null,
        createQuill: function (quillElement) {
            if (!quillElement)
                return;
            var toolbarOptions =
                [
                    ['bold', 'italic', 'underline', 'strike'],
                    [{ 'align': [] }],
                    [{ 'font': [] }], ,
                    ['code-block', 'code', 'blockquote'],
                    [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
                    [{ 'size': ['small', false, 'large', 'huge'] }],  // custom dropdown
                    [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
                    [{ 'list': 'ordered' }, { 'list': 'bullet' }],
                    [{ 'direction': 'rtl' }],
                    [{ 'indent': '-1' }, { 'indent': '+1' }],
                    ['clean'],
                    ['image', 'video'],
                    [{ 'script': 'sub' }, { 'script': 'super' }],      // superscript/subscript
                    ['link'],
                ]

            var options = {
                debug: 'info',
                modules: {
                    toolbar: toolbarOptions,
                    history: {
                        delay: 2000,
                        maxStack: 500,
                        userOnly: true
                    },
                    syntax: true,
                },
                placeholder: 'Compose an epic...',
                readOnly: false,
                theme: 'snow'
            };
            // set quill at the object we can call
            // methods on later
            new Quill(quillElement, options);
        },
        removeQuillToolbar: function () {
            var toolbar = document.querySelector(".ql-toolbar.ql-snow");
            if (toolbar) {
                toolbar.parentNode.removeChild(toolbar);
            }
        },
        getQuillContent: function (quillControl) {
            return JSON.stringify(quillControl.__quill.getContents());
        },
        getQuillText: function (quillControl) {
            return quillControl.__quill.getText();
        },
        getQuillHTML: function (quillControl) {
            return quillControl.__quill.root.innerHTML;
        }

    };
})();