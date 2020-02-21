namespace LINQ_Assignment
{
	public class Screen
	{
		public float Diagonal { get; set; }
		public MatrixTypes MatrixType { get; set; }

		public Screen(float _diagonal, MatrixTypes _matrixType)
		{
			Diagonal = _diagonal;
			MatrixType = _matrixType;
		}

		public override string ToString()
		{
			return $"Diagonal: { Diagonal }, Matrix: { MatrixType }";
		}
	}
}