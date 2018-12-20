namespace KnapsackAlgorithm
{
    public class Piece
    {
        public string Name { get; set; }
        public float Length { get; set; }
        
        public Piece()
        {            
        }
        
        public CutPiece ToCutPiece(int scale)
        {
            var piece = new CutPiece(this, scale);
            return piece;
        }
    }
}
