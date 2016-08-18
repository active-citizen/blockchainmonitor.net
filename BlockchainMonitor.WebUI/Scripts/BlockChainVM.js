function BlockChainVM(model) {
    var _allBlocks = [];
    model.AllBlocks.forEach(function (block) {
        _allBlocks.push(new BlockVM(block))
    });
    this.allBlocks = ko.observableArray(_allBlocks);

    var _statistics = model.Statistics;
    this.statistics = {
        blocksCount: ko.observable(_statistics.BlocksCount),
        transactionsCount: ko.observable(_statistics.TransactionsCount),
        dataBaseSizeGB: ko.observable(_statistics.DataBaseSizeGB),
        smartContractsCount: ko.observable(_statistics.SmartContractsCount),
        validatingNodesCount: ko.observable(_statistics.ValidatingNodesCount),
        nonValidatingNodesCount: ko.observable(_statistics.NonValidatingNodesCount),
    };
}

function BlockVM(model) {
    this.transactionsCount = ko.observable(model.TransactionsCount);
    this.number = model.Number;
}

function lastBlockTransactionCount(count) {
    model.allBlocks()[model.allBlocks().length - 1].transactionsCount(count);
}