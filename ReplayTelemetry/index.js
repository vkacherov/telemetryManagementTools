module.exports = function(context, req, jsonBlob) {
    context.log("Retrieved records:", jsonBlob);

    let result = "";
    // Parse the blob JSON
    JSON.parse(jsonBlob, (key, value) => {
        result[key] = value;
        context.log("Adding key:" + key + ", value:" + value);
    });

    context.res = {
        status: 200,
        body: result
    };
    context.done();
};