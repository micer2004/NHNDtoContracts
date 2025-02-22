using System;
using System.Runtime.Serialization;

namespace NHN.DtoContracts.Common.en
{
    /// <summary>
    /// Fysisk adresse, f.eks. bes�ks-, post- eller fakturaadresse.
    /// </summary>
    [DataContract(Namespace = CommonXmlNamespaces.XmlNsCommonEnglishOld)]
    [Serializable]
    public class PhysicalAddress
    {
        /// <summary>
        /// Note: Reference to Type will not be cloned.
        /// </summary>
        public PhysicalAddress Clone()
        {
            return (PhysicalAddress)MemberwiseClone();
        }

        /// <summary>
        /// Dato og tid for siste endring til objektet
        /// </summary>
        [DataMember]
        public DateTime LastChanged { get; set; }

        #pragma warning disable 618 ///TypeCodeValue is Obsolete, it is here because of historical reasons.
        private Code _type;
        /// <summary>
        /// Type adresse. (RES/PST/ osv)
        /// </summary>
        [DataMember]
        public Code Type
        {
            get
            {
                if (_type == null && !string.IsNullOrEmpty(TypeCodeValue))
                    _type = CreateAddressTypeCode(TypeCodeValue);

                return _type;
            }

            set
            {
                if (value != null)
                {
                    if (value.OID != 0 && value.OID != 3401)
                        throw new InvalidOperationException("PhysicalAddress can only have OID value 3401");
                    if (!string.IsNullOrEmpty(value.SimpleType) && value.SimpleType != "adressetype")
                        throw new InvalidOperationException("PhysicalAddress can only have code group 'adressetype'");
                }

                _type = value;
                if (_type != null && TypeCodeValue != _type.CodeValue)
                    TypeCodeValue = _type.CodeValue;
            }
        }
        #pragma warning restore 618

        /// <summary>
        /// Type adresse, f.eks. bes�ks-, post- eller fakturaadresse.
        /// Gyldige verdier: OID 3401
        /// </summary>
        [DataMember]
        [Obsolete("Use Type instead")]
        public string TypeCodeValue { get; set; }

        /// <summary>
        /// Postboks
        /// </summary>
        [DataMember]
        public string Postbox { get; set; }

        /// <summary>
        /// Gateadresse
        /// </summary>
        [DataMember]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Postkode
        /// </summary>
        [DataMember]
        public int PostalCode { get; set; }

        /// <summary>
        /// Poststed
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// Fritekst felt for ekstra beskrivelse. For eksempel �Samme inngang som ICA, ta innerste d�r til venstre�
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Hvorvidt adressen er arvet.
        /// </summary>
        [DataMember]
        public bool Inherited { get; set; }

        /// <summary>
        /// Landkode
        /// </summary>
        [DataMember]
        public Code Country { get; set; }

        public static Code CreateAddressTypeCode(string codeValue)
        {
            return new Code("adressetype", 3401, codeValue);
        }
    }
}