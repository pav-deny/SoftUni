function extract(elementId) {
    let element = document.getElementById(elementId);
    let text = element.textContent;

    let pattern = /\(.*?\)/g;
    let matches = text.match(pattern);
    return (matches.map(m => m.slice(1, -1)).join("; "));
}