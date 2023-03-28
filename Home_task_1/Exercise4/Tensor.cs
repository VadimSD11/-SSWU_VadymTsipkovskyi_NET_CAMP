using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    internal class Tensor<T>
    {
        private readonly int[] _dimensions;
        private readonly T[] _values;

        public Tensor(params int[] dimensions)
        {
            if (dimensions == null || dimensions.Length == 0)
            {
                throw new ArgumentException("At least one dimension is required.", nameof(dimensions));
            }

            _dimensions = dimensions;
            _values = new T[CalculateSize(dimensions)];
        }

        public int[] Dimensions => (int[])_dimensions.Clone();

        public T GetValue(params int[] indices)
        {
            if (indices == null || indices.Length != _dimensions.Length)
            {
                throw new ArgumentException("Indices must have the same length as the tensor dimensions.", nameof(indices));
            }

            int offset = CalculateOffset(indices);
            return _values[offset];
        }

        public void SetValue(T value, params int[] indices)
        {
            if (indices == null || indices.Length != _dimensions.Length)
            {
                throw new ArgumentException("Indices must have the same length as the tensor dimensions.", nameof(indices));
            }

            int offset = CalculateOffset(indices);
            _values[offset] = value;
        }

        private int CalculateSize(int[] dimensions)
        {
            int size = 1;
            foreach (int dim in dimensions)
            {
                if (dim <= 0)
                {
                    throw new ArgumentException("Dimensions must be positive.", nameof(dimensions));
                }

                size *= dim;
            }

            return size;
        }

        private int CalculateOffset(int[] indices)
        {
            int offset = 0;
            int stride = 1;

            for (int i = _dimensions.Length - 1; i >= 0; i--)
            {
                int index = indices[i];
                if (index < 0 || index >= _dimensions[i])
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }

                offset += index * stride;
                stride *= _dimensions[i];
            }

            return offset;
        }
    
}
}
