using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.Infra.GatewayPayment.Const
{
    public static class PaymentEvents
    {
        public const string PaymentCreated = "PAYMENT_CREATED"; // Geração de nova cobrança.
        public const string PaymentAwaitingRiskAnalysis = "PAYMENT_AWAITING_RISK_ANALYSIS"; // Pagamento em cartão aguardando aprovação pela análise manual de risco.
        public const string PaymentApprovedByRiskAnalysis = "PAYMENT_APPROVED_BY_RISK_ANALYSIS"; // Pagamento em cartão aprovado pela análise manual de risco.
        public const string PaymentReprovedByRiskAnalysis = "PAYMENT_REPROVED_BY_RISK_ANALYSIS"; // Pagamento em cartão reprovado pela análise manual de risco.
        public const string PaymentAuthorized = "PAYMENT_AUTHORIZED"; // Pagamento em cartão que foi autorizado e precisa ser capturado.
        public const string PaymentUpdated = "PAYMENT_UPDATED"; // Alteração no vencimento ou valor de cobrança existente.
        public const string PaymentConfirmed = "PAYMENT_CONFIRMED"; // Cobrança confirmada (pagamento efetuado, porém o saldo ainda não foi disponibilizado).
        public const string PaymentReceived = "PAYMENT_RECEIVED"; // Cobrança recebida.
        public const string PaymentCreditCardCaptureRefused = "PAYMENT_CREDIT_CARD_CAPTURE_REFUSED"; // Falha no pagamento de cartão de crédito.
        public const string PaymentAnticipated = "PAYMENT_ANTICIPATED"; // Cobrança antecipada.
        public const string PaymentOverdue = "PAYMENT_OVERDUE"; // Cobrança vencida.
        public const string PaymentDeleted = "PAYMENT_DELETED"; // Cobrança removida.
        public const string PaymentRestored = "PAYMENT_RESTORED"; // Cobrança restaurada.
        public const string PaymentRefunded = "PAYMENT_REFUNDED"; // Cobrança estornada.
        public const string PaymentPartiallyRefunded = "PAYMENT_PARTIALLY_REFUNDED"; // Cobrança estornada parcialmente.
        public const string PaymentRefundInProgress = "PAYMENT_REFUND_IN_PROGRESS"; // Estorno em processamento (liquidação já está agendada, cobrança será estornada após executar a liquidação).
        public const string PaymentReceivedInCashUndone = "PAYMENT_RECEIVED_IN_CASH_UNDONE"; // Recebimento em dinheiro desfeito.
        public const string PaymentChargebackRequested = "PAYMENT_CHARGEBACK_REQUESTED"; // Recebido chargeback.
        public const string PaymentChargebackDispute = "PAYMENT_CHARGEBACK_DISPUTE"; // Em disputa de chargeback (caso sejam apresentados documentos para contestação).
        public const string PaymentAwaitingChargebackReversal = "PAYMENT_AWAITING_CHARGEBACK_REVERSAL"; // Disputa vencida, aguardando repasse da adquirente.
        public const string PaymentDunningReceived = "PAYMENT_DUNNING_RECEIVED"; // Recebimento de negativação.
        public const string PaymentDunningRequested = "PAYMENT_DUNNING_REQUESTED"; // Requisição de negativação.
        public const string PaymentBankSlipViewed = "PAYMENT_BANK_SLIP_VIEWED"; // Boleto da cobrança visualizado pelo cliente.
        public const string PaymentCheckoutViewed = "PAYMENT_CHECKOUT_VIEWED"; // Fatura da cobrança visualizada pelo cliente.
    }

}
