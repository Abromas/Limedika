import { Buffer } from 'buffer';

window.Buffer = window.Buffer || Buffer;

window.checkNullValues = () => false;

window.showAlert = message => alert(message);

window.BlazorDownloadFile = (fileName, href) => {
    const link = document.createElement('a');
    link.download = fileName;
    link.href = href;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

window.triggerFileInputClick = inputElement => inputElement.click();

window.openInNewTab = url => window.open(url, '_blank').focus();
