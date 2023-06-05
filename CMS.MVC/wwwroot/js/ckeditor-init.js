$(function () {
    ClassicEditor.create(document.querySelector('.ckeditor'), {
        ckfinder: {
            uploadUrl: '/ckfinder/core/connector/dotnet/connector.aspx?command=QuickUpload&type=Files',
            imageUploadUrl: '/ckfinder/core/connector/dotnet/connector.aspx?command=QuickUpload&type=Images'
        }
    });
});
