namespace CJia.MobileMedicalDoctor.Serialization
{
	/// <summary>
	/// Enum which is used for fast serialization. It stores information about a type or type/value.
	/// </summary>
    public enum SerializedType : byte
	{
		// Codes 0 to 127 reserved for String token tables
        /// <summary>
        /// Used for all null values
        /// </summary>
		NullType = 128,
		/// <summary>
        /// Used internally to identify sequences of null values in object[]
		/// </summary>
        NullSequenceType,
		/// <summary>
        /// Used for DBNull.Value
		/// </summary>
        DBNullType,
		/// <summary>
        /// Used internally to identify sequences of DBNull.Value values in object[] (DataSets)
		/// </summary>
        DBNullSequenceType,
		/// <summary>
        /// Used for any unrecognized types - uses an internal BinaryWriter/Reader.
		/// </summary>
        OtherType,
        /// <summary>
        /// Stores Boolean type and values
        /// </summary>
		BooleanTrueType,
		/// <summary>
        /// Stores Boolean type and values
		/// </summary>
        BooleanFalseType,
        /// <summary>
        /// Standard numeric value types
        /// </summary>
		ByteType,
		/// <summary>
        /// Standard numeric value types
		/// </summary>
        SByteType,
        /// <summary>
        /// Standard numeric value types
        /// </summary>
		CharType,
        /// <summary>
        /// Standard numeric value types
        /// </summary>
		DecimalType,
        /// <summary>
        /// Standard numeric value types
        /// </summary>
		DoubleType,
        /// <summary>
        /// Standard numeric value types
        /// </summary>
		SingleType,
        /// <summary>
        /// Standard numeric value types
        /// </summary>
		Int16Type,
        /// <summary>
        /// Standard numeric value types
        /// </summary>
		Int32Type,
        /// <summary>
        /// Standard numeric value types
        /// </summary>
		Int64Type,
        /// <summary>
        /// Standard numeric value types
        /// </summary>
		UInt16Type,
        /// <summary>
        /// Standard numeric value types
        /// </summary>
		UInt32Type,
        /// <summary>
        /// Standard numeric value types
        /// </summary>
		UInt64Type,
        /// <summary>
        /// Optimization to store type and a zero value - all numeric value types
        /// </summary>
		ZeroByteType,
		/// <summary>
        /// Optimization to store type and a zero value - all numeric value types
		/// </summary>
        ZeroSByteType,
		/// <summary>
        /// Optimization to store type and a zero value - all numeric value types
		/// </summary>
        ZeroCharType,
		/// <summary>
        /// Optimization to store type and a zero value - all numeric value types
		/// </summary>
        ZeroDecimalType,
		/// <summary>
        /// Optimization to store type and a zero value - all numeric value types
		/// </summary>
        ZeroDoubleType,
		/// <summary>
        /// Optimization to store type and a zero value - all numeric value types
		/// </summary>
        ZeroSingleType,
		/// <summary>
        /// Optimization to store type and a zero value - all numeric value types
		/// </summary>
        ZeroInt16Type,
		/// <summary>
        /// Optimization to store type and a zero value - all numeric value types
		/// </summary>
        ZeroInt32Type,
		/// <summary>
        /// Optimization to store type and a zero value - all numeric value types
		/// </summary>
        ZeroInt64Type,
		/// <summary>
        /// Optimization to store type and a zero value - all numeric value types
		/// </summary>
        ZeroUInt16Type,
		/// <summary>
        /// Optimization to store type and a zero value - all numeric value types
		/// </summary>
        ZeroUInt32Type,
		/// <summary>
        /// Optimization to store type and a zero value - all numeric value types
		/// </summary>
        ZeroUInt64Type,
        /// <summary>
        /// Optimization to store type and a one value - all numeric value types
        /// </summary>
		OneByteType,
		/// <summary>
        /// Optimization to store type and a one value - all numeric value types
		/// </summary>
        OneSByteType,
		/// <summary>
        /// Optimization to store type and a one value - all numeric value types
		/// </summary>
        OneCharType,
		/// <summary>
        /// Optimization to store type and a one value - all numeric value types
		/// </summary>
        OneDecimalType,
		/// <summary>
        /// Optimization to store type and a one value - all numeric value types
		/// </summary>
        OneDoubleType,
		/// <summary>
        /// Optimization to store type and a one value - all numeric value types
		/// </summary>
        OneSingleType,
		/// <summary>
        /// Optimization to store type and a one value - all numeric value types
		/// </summary>
        OneInt16Type,
		/// <summary>
        /// Optimization to store type and a one value - all numeric value types
		/// </summary>
        OneInt32Type,
		/// <summary>
        /// Optimization to store type and a one value - all numeric value types
		/// </summary>
        OneInt64Type,
		/// <summary>
        /// Optimization to store type and a one value - all numeric value types
		/// </summary>
        OneUInt16Type,
		/// <summary>
        /// Optimization to store type and a one value - all numeric value types
		/// </summary>
        OneUInt32Type,
		/// <summary>
        /// Optimization to store type and a one value - all numeric value types
		/// </summary>
        OneUInt64Type,
        /// <summary>
        /// Optimization to store type and a minus one value - Signed Integer types only
        /// </summary>
		MinusOneInt16Type,
		/// <summary>
        /// Optimization to store type and a minus one value - Signed Integer types only
		/// </summary>
        MinusOneInt32Type,
		/// <summary>
        /// Optimization to store type and a minus one value - Signed Integer types only
		/// </summary>
        MinusOneInt64Type,
        /// <summary>
        /// Optimizations for specific value types
        /// </summary>
		OptimizedInt16Type,
		/// <summary>
        /// Optimizations for specific value types
		/// </summary>
        OptimizedInt16NegativeType,
		/// <summary>
        /// Optimizations for specific value types
		/// </summary>
        OptimizedUInt16Type,
		/// <summary>
        /// Optimizations for specific value types
		/// </summary>
        OptimizedInt32Type,
		/// <summary>
        /// Optimizations for specific value types
		/// </summary>
        OptimizedInt32NegativeType,
		/// <summary>
        /// Optimizations for specific value types
		/// </summary>
        OptimizedUInt32Type,
		/// <summary>
        /// Optimizations for specific value types
		/// </summary>
        OptimizedInt64Type,
		/// <summary>
        /// Optimizations for specific value types
		/// </summary>
        OptimizedInt64NegativeType,
		/// <summary>
        /// Optimizations for specific value types
		/// </summary>
        OptimizedUInt64Type,
		/// <summary>
        /// Optimizations for specific value types
		/// </summary>
        OptimizedDateTimeType,
		/// <summary>
        /// Optimizations for specific value types
		/// </summary>
        OptimizedTimeSpanType,

        /// <summary>
        /// String type and optimizations
        /// </summary>
		EmptyStringType,
		/// <summary>
        /// String type and optimizations
		/// </summary>
        SingleSpaceType,
		/// <summary>
        /// String type and optimizations
		/// </summary>
        SingleCharStringType,
		/// <summary>
        /// String type and optimizations
		/// </summary>
        YStringType,
		/// <summary>
        /// String type and optimizations
		/// </summary>
        NStringType,
        /// <summary>
        /// Date type and optimizations
        /// </summary>
		DateTimeType,
		/// <summary>
        /// Date type and optimizations
		/// </summary>
        MinDateTimeType,
		/// <summary>
        /// Date type and optimizations
		/// </summary>
        MaxDateTimeType,
        /// <summary>
        /// TimeSpan type and optimizations
        /// </summary>
		TimeSpanType,
		/// <summary>
        /// TimeSpan type and optimizations
		/// </summary>
        ZeroTimeSpanType,
        /// <summary>
        /// Guid type and optimizations
        /// </summary>
		GuidType,
		/// <summary>
        /// Guid type and optimizations
		/// </summary>
        EmptyGuidType,
        /// <summary>
        /// Specific optimization for BitVector32 type
        /// </summary>
		BitVector32Type,
        /// <summary>
        /// Used internally by Optimized object[] pair to identify values 
        /// in the second array that are identical to those in the first
        /// </summary>
		DuplicateValueType,
        /// <summary>
        /// Used internally by Optimized object[] pair to identify values 
        /// in the second array that are identical to those in the first
        /// </summary>
		DuplicateValueSequenceType,
        /// <summary>
        /// Specific optimization for BitArray
        /// </summary>
		BitArrayType,
        /// <summary>
        /// Identifies a Type type 
        /// </summary>
		TypeType,
        /// <summary>
        /// Used internally to identify that a single instance object should be created
        /// (by storing the Type and using Activator.GetInstance() at deserialization time)
        /// </summary>
		SingleInstanceType,        
        /// <summary>
        /// Specific optimization for ArrayList type
        /// </summary>
		ArrayListType,

        /// <summary>
        /// Array types
        /// </summary>
		ObjectArrayType,
		/// <summary>
        /// Array types
		/// </summary>
        EmptyTypedArrayType,
		/// <summary>
        /// Array types
		/// </summary>
        EmptyObjectArrayType,
        /// <summary>
        /// Identifies a typed array and how it is optimized
        /// </summary>
		NonOptimizedTypedArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        FullyOptimizedTypedArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        PartiallyOptimizedTypedArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        OtherTypedArrayType,
        /// <summary>
        /// Identifies a typed array and how it is optimized
        /// </summary>
		BooleanArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        ByteArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        CharArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        DateTimeArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        DecimalArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        DoubleArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        SingleArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        GuidArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        Int16ArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        Int32ArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        Int64ArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        SByteArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        TimeSpanArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        UInt16ArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        UInt32ArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        UInt64ArrayType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        StringArrayType,
        /// <summary>
        /// Identifies a typed array and how it is optimized
        /// </summary>
		OwnedDataSerializableAndRecreatableType,
        /// <summary>
        /// Identifies a typed array and how it is optimized
        /// </summary>
		EnumType,
		/// <summary>
        /// Identifies a typed array and how it is optimized
		/// </summary>
        OptimizedEnumType,
        /// <summary>
        /// Identifies a typed array and how it is optimized
        /// </summary>
		SurrogateHandledType,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
		Reserved24,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
        Reserved23,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
        Reserved22,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
        Reserved21,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
        Reserved20,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
        Reserved19,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
        Reserved18,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
        Reserved17,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
        Reserved16,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
        Reserved15,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
        Reserved14,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
        Reserved13,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
        Reserved12,
		/// <summary>
        /// Placeholders to indicate number of Type Codes remaining
		/// </summary>
        Reserved11,
        /// <summary>
        /// Placeholders to indicate number of Type Codes remaining
        /// </summary>
        Reserved10,
        /// <summary>
        /// Placeholders to indicate number of Type Codes remaining
        /// </summary>
		Reserved9,
        /// <summary>
        /// Placeholders to indicate number of Type Codes remaining
        /// </summary>
		Reserved8,
        /// <summary>
        /// Placeholders to indicate number of Type Codes remaining
        /// </summary>
		Reserved7,
        /// <summary>
        /// Placeholders to indicate number of Type Codes remaining
        /// </summary>
		Reserved6,
        /// <summary>
        /// Placeholders to indicate number of Type Codes remaining
        /// </summary>
		Reserved5,
        /// <summary>
        /// Placeholders to indicate number of Type Codes remaining
        /// </summary>
		Reserved4,
        /// <summary>
        /// Placeholders to indicate number of Type Codes remaining
        /// </summary>
		Reserved3,
        /// <summary>
        /// Placeholders to indicate number of Type Codes remaining
        /// </summary>
		Reserved2,
        /// <summary>
        /// Placeholders to indicate number of Type Codes remaining
        /// </summary>
		Reserved1
	}
}