using LLama.Abstractions;
using LLama.Common;
using LLama.Native;
using LLama.Sampling;

namespace Core.LLama.Common
{
    public class InferenceOptions : IInferenceParams
    {
        /// <inheritdoc />
        public int TokensKeep { get; set; } = 0;
        /// <inheritdoc />
        public int MaxTokens { get; set; } = -1;
        /// <inheritdoc />
        public Dictionary<LLamaToken, float>? LogitBias { get; set; } = null;
        /// <inheritdoc />
        public IReadOnlyList<String> AntiPrompts { get; set; } = Array.Empty<String>();
        /// <inheritdoc />
        public int TopK { get; set; } = 40;
        /// <inheritdoc />
        public float TopP { get; set; } = 0.95f;
        /// <inheritdoc />
        public float MinP { get; set; } = 0.05f;
        /// <inheritdoc />
        public float TfsZ { get; set; } = 1.0f;
        /// <inheritdoc />
        public float TypicalP { get; set; } = 1.0f;
        /// <inheritdoc />
        public float Temperature { get; set; } = 0.8f;
        /// <inheritdoc />
        public float RepeatPenalty { get; set; } = 1.1f;
        /// <inheritdoc />
        public int RepeatLastTokensCount { get; set; } = 64;
        /// <inheritdoc />
        public float FrequencyPenalty { get; set; } = .0f;
        /// <inheritdoc />
        public float PresencePenalty { get; set; } = .0f;
        /// <inheritdoc />
        public MirostatType Mirostat { get; set; } = MirostatType.Disable;
        /// <inheritdoc />
        public float MirostatTau { get; set; } = 5.0f;
        /// <inheritdoc />
        public float MirostatEta { get; set; } = 0.1f;
        /// <inheritdoc />
        public bool PenalizeNL { get; set; } = true;
        ///// <summary>
        ///// A grammar to constrain possible tokens
        ///// </summary>
        //public required SafeLLamaGrammarHandle Grammar { get; set; }
        /// <inheritdoc />
        public required ISamplingPipeline SamplingPipeline { get; set; }
    }
}
