function updateMetaTag(property, content) {
    let element = document.querySelector(`meta[property='${property}']`);
    if (element) {
        element.setAttribute("content", content);
    }
    else {
        element = document.createElement('meta');
        element.setAttribute('property', property);
        element.setAttribute('content', content);
        document.getElementsByTagName('head')[0].appendChild(element);
    }
}