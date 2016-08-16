function BlockChainVM(model) {
    var _allBlocks = [];
    model.AllBlocks.forEach(function (block) {
        _allBlocks.push(new BlockVM(block))
    });
    this.allBlocks = ko.observableArray(_allBlocks);
}

function BlockVM(model) {
    this.transactionsCount = ko.observable(model.TransactionsCount);
    this.number = model.Number;
}

function lastBlockTransactionCount(count) {
    model.allBlocks()[model.allBlocks().length - 1].transactionsCount(count);
}