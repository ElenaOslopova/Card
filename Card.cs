namespace Cards
{
    public sealed class Card
    {
        private string input;
        private string output;

        public Card(string input, string output)
        {
            this.input = input;
            this.output = output;
        }

        public string Input { get { return this.input; } }
        public string Output { get { return this.output; } }
    }
}
