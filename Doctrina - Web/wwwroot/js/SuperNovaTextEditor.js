
window.onload = function () {
    var editor = document.getElementById("TextEditPlace");
    console.log(editor.contentDocument);
    editor.contentDocument.designMode = 'on';
    start();
}

function execCmd(arg) {
    if (arg == 'bold') {
        console.log('bold');
    }
}