window.writeTestMessage = () => {
    console.log("this is a test");
};

//function openNewTab(url){
//    window.open(url, '_blank');
//};

window.saveFile = async function (fileName, content) {
    try {
        // Create a new handle
        const handle = await window.showSaveFilePicker({
            suggestedName: fileName,
            types: [{
                description: 'JSON Files',
                accept: { 'application/json': ['.json'] },
            }],
        });

        // Create a FileSystemWritableFileStream to write to
        const writable = await handle.createWritable();

        // Write the content to the file.
        await writable.write(content);

        // Close the file and write the contents to disk.
        await writable.close();
    } catch (e) {
        console.error(e);
    }
};

window.loadFile = async function () {
    return new Promise((resolve, reject) => {
        const input = document.createElement('input');
        input.type = 'file';
        input.accept = 'application/json';

        input.onchange = async () => {
            const file = input.files[0];
            if (!file) {
                reject('No file selected');
                return;
            }

            const reader = new FileReader();
            reader.onload = () => resolve(reader.result);
            reader.onerror = () => reject(reader.error);

            reader.readAsText(file);
        };

        input.click();
    });
};




function setInputValue(element, value) {
    element.value = value;
}




