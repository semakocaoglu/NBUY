function convertToShortDate(dateString) {
    const shortDate = new Date(dateString).toLocaleDateString('tr-Tr')
    return shortDate;

}
function convertFirstLetterToUpperCase(text) {
    text = text.toString();
    const convertedText = text.charAt(0).ToUpperCase() + text.slice(1).toLowerCase();
    return convertedText;
}

