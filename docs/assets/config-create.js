function onFrameLoaded(frameNode) {

    function setToObject(targetObject, path, value) {
        var segments = path.split(".");

        let innerTargetObject = targetObject;
        for (let i = 0; i < segments.length - 1; i++) {
            let segment = segments[i];

            if (innerTargetObject[segment] == undefined) {
                innerTargetObject[segment] = {};
            }

            innerTargetObject = innerTargetObject[segment];
        }

        let fieldName = segments[segments.length - 1];
        innerTargetObject[fieldName] = value;
    }

    function sortObjByKey(targetObject, sortKeys) {
        if (typeof targetObject === 'object') {
            return Object.keys(targetObject).sort((a, b) => {
                var indexOfA = sortKeys.indexOf(a);
                var indexOfB = sortKeys.indexOf(b);
                return indexOfA - indexOfB;
            }).reduce(
                (result, key) => {
                    const value = targetObject[key];
                    result[key] = sortObjByKey(value, sortKeys);
                    return result;
                }, {});
        } else {
            return targetObject;
        }
    }

    function saveTextFile(text, filename) {
        var a = document.createElement('a');
        a.setAttribute('href', 'data:text/plain;charset=utf-u,' + encodeURIComponent(text));
        a.setAttribute('download', filename);
        a.click()
    }

    frameNode.querySelector("#generate-config-button").onclick = () => {
        let configObject = {};
        let sortedKeys = [];

        frameNode.querySelectorAll(".field-input").forEach(el => {
            let field = el.dataset.field;
            let value;
            switch (el.type) {
                case "checkbox":
                    value = el.checked;
                    break;
                case "number":
                    value = el.valueAsNumber;
                    break;
                default:
                    value = el.value;
                    break;
            }

            field.split(".").forEach(name => {
                if (sortedKeys.indexOf(name) < 0) {
                    sortedKeys.push(name);
                }
            });
            setToObject(configObject, field, value);
        });

        var json = JSON.stringify(sortObjByKey(configObject, sortedKeys), null, 2);
        saveTextFile(json, "config.json");
    }

}

(function (frameNode) {
    fetch("assets/config-create-frame.html")
        .then(r => r.text())
        .then(html => {
            frameNode.innerHTML = html;
            onFrameLoaded(frameNode);
        });
})(document.querySelector("#config-create-frame"));