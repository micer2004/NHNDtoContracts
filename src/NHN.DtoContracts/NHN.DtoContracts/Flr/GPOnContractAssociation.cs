﻿using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr
{
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    public class GPOnContractAssociation
    {
        /// <summary>
        /// Denne ID'en eies av FLO.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Fastlegeavtale/liste
        /// </summary>
        [DataMember]
        public GPContract GPContract { get; set; }

        /// <summary>
        /// HPR nummeret til legen
        /// </summary>
        [DataMember]
        public int DoctorHprNumber { get; set; }

        /// <summary>
        /// Hvis satt, så representerer denne GPOnContract en vikar, og dette feltet viser for hvilken lege han er vikar.
        /// </summary>
        [DataMember]
        public int? SubstituteForDoctorHprNumber { get; set; } //VikarForLege

        /// <summary>
        /// Når er denne knytningen gyldig.
        /// </summary>
        [DataMember]
        public Period Valid { get; set; }

        /// <summary>
        /// Hvordan type knytning er dette mot GPContract
        /// </summary>
        [DataMember]
        public Code Relationship { get; set; } //ForholdsKode;

        /// <summary>
        /// Avslutningsårsak
        /// </summary>
        [DataMember]
        public Code EndOfCycleReason { get; set; }
    }
}