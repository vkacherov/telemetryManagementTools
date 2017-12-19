module.exports = function(context, req, jsonBlob) {
    context.log("Retrieved records:", jsonBlob);
    context.res = {
        status: 200,
        body: jsonBlob
    };
    context.done();
};