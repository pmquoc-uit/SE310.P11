﻿namespace Core.LLama.Common
{
    public class LLamaOptions
    {
        public ModelLoadType ModelLoadType { get; set; }
        public List<ModelOptions> Models { get; set; } = [];
    }
}
