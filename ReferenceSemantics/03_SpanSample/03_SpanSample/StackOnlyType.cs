namespace _03_SpanSample
{
    ref struct StackOnlyType
    {
        public int X { get; set; }

        public override string ToString() => nameof(StackOnlyType);
    }
}
