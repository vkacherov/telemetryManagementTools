module.exports = function(context, req, jsonBlob) {
    context.log("Retrieved blob data:", jsonBlob);

    // Parse the blob JSON    
    let result = JSON.parse(jsonBlob);
    context.log("Found records:", Object.keys(result).length);

    context.res = {
        status: 200,
        body: result
    };
    context.done();
};