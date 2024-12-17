﻿using LLama.Abstractions;
using LLama.Native;
using System.Text;

namespace Core.LLama.Common
{
    public class ModelOptions : ILLamaParams
    {
        /// <summary>
        /// Model friendly name
        /// </summary>
        public String Name { get; set; } = String.Empty;
        /// <summary>
        /// Max context insta=nces allowed per model
        /// </summary>
        public int MaxInstances { get; set; }
        /// <inheritdoc />
        public uint? ContextSize { get; set; }
        /// <inheritdoc />
        public int MainGpu { get; set; } = 0;
        /// <inheritdoc />
        public GPUSplitMode SplitMode { get; set; } = GPUSplitMode.None;
        /// <inheritdoc />
        public int GpuLayerCount { get; set; } = 20;
        /// <inheritdoc />
        public uint SeqMax { get; set; }
        /// <inheritdoc />
        public uint? Seed { get; set; } = 1686349486;
        /// <inheritdoc />
        public Boolean Embeddings { get; set; }
        /// <inheritdoc />
        public Boolean UseMemorymap { get; set; } = true;
        /// <inheritdoc />
        public Boolean UseMemoryLock { get; set; } = false;
        /// <inheritdoc />
        public String ModelPath { get; set; } = String.Empty;
        /// <inheritdoc />
        public int? Threads { get; set; }
        /// <inheritdoc />
        public int? BatchThreads { get; set; }
        /// <inheritdoc />
        public uint BatchSize { get; set; } = 512;
        /// <inheritdoc />
        public uint UBatchSize { get; set; } = 512;
        /// <inheritdoc />
        public TensorSplitsCollection TensorSplits { get; set; } = new();
        /// <inheritdoc />
        public List<MetadataOverride> MetadataOverrides { get; } = [];
        /// <inheritdoc />
        public float? RopeFrequencyBase { get; set; }
        /// <inheritdoc />
        public float? RopeFrequencyScale { get; set; }
        /// <inheritdoc />
        public float? YarnExtrapolationFactor { get; set; }
        /// <inheritdoc />
        public float? YarnAttentionFactor { get; set; }
        /// <inheritdoc />
        public float? YarnBetaFast { get; set; }
        /// <inheritdoc />
        public float? YarnBetaSlow { get; set; }
        /// <inheritdoc />
        public uint? YarnOriginalContext { get; set; }
        /// <inheritdoc />
        public RopeScalingType? YarnScalingType { get; set; }
        /// <inheritdoc />
        public GGMLType? TypeK { get; set; }
        /// <inheritdoc />
        public GGMLType? TypeV { get; set; }
        /// <inheritdoc />
        public Boolean NoKqvOffload { get; set; }
        /// <inheritdoc />
        public Boolean FlashAttention { get; set; }
        /// <inheritdoc />
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        /// <inheritdoc />
        public Boolean VocabOnly { get; set; }
        /// <inheritdoc />
        public float? DefragThreshold { get; set; }
        /// <inheritdoc />
        public LLamaPoolingType PoolingType { get; set; }
        /// <inheritdoc />
        public LLamaAttentionType AttentionType { get; set; } = LLamaAttentionType.Unspecified;
    }
}
