function BlockChainVM(model) {
    var self = this;

    var _allBlocks = [];
    model.allBlocks.forEach(function (block) {
        _allBlocks.push(new BlockVM(block))
    });
    this.allBlocks = ko.observableArray(_allBlocks);

    var _statistics = model.statistics;
    this.statistics = {
        blocksCount: ko.observable(_statistics.blocksCount),
        transactionsCount: ko.observable(_statistics.transactionsCount),
        dataBaseSizeGB: ko.observable(_statistics.dataBaseSizeGB),
        smartContractsCount: ko.observable(_statistics.smartContractsCount),
        validatingNodesCount: ko.observable(_statistics.validatingNodesCount),
        nonValidatingNodesCount: ko.observable(_statistics.nonValidatingNodesCount),
    };

    this.transactions = ko.observableArray(model.lastTransactions);

    this.updateLastBlockTransactionCount = _updateLastBlockTransactionCount;

    function _updateLastBlockTransactionCount(count) {
        self.allBlocks()[self.allBlocks().length - 1].transactionsCount(count);
    }

    this.updateLastTransactions = _updateLastTransactions;
    function _updateLastTransactions(currentTransactions) {
        var previousTransactions = self.transactions();
        var previousTransactionsMap = previousTransactions.reduce(function (result, tran) {
            result[tran.id] = tran;
            return result;
        }, {} );
        var newTransactions = currentTransactions.filter(function (tran) {
            return previousTransactionsMap[tran.id] === undefined;
        });
        if (newTransactions.length === 0) return;

        var newLength = self.transactions.unshift.apply(self.transactions, newTransactions);

        const maxLength = 8;
        if (newLength <= maxLength) return;
        self.transactions.splice(maxLength, newLength - maxLength);

        _animateTransactions();
    }

    this.animateTransactions = _animateTransactions;
    function _animateTransactions() {
        $('.transactions-list .transaction.in-transition').toggleClass('in-transition');
    }
}

function BlockVM(model) {
    this.transactionsCount = ko.observable(model.transactionsCount);
    this.number = model.number;
}