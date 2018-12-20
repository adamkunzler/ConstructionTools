namespace KnapsackAlgorithm
{
    /// <summary>
    /// Represents a piece scaled to x units and includes the cut length
    /// </summary>
    public class CutPiece
    {        
        public string Name { get; set; }
        public int UnitLength { get; set; }
        public int CutSize => 1;
        public int Scale { get; private set; }

        public CutPiece(Piece p, int scale)
        {
            Scale = scale;
            Name = p.Name;

            // scale the piece length and add length for the cut
            UnitLength = (int)(p.Length * Scale) + CutSize;
        }

        public Piece ToPiece()
        {
            var piece = new Piece
            {
                Name = Name,
                Length = (UnitLength - CutSize) / Scale
            };

            return piece;
        }
    }
}
