function displayProperties() {
    var docProperties = [],
        property;
    
    for (property in document) {
        docProperties.push(property);
    }
    
    docProperties.sort();
    console.info(docProperties.join('\n'));
}

displayProperties();