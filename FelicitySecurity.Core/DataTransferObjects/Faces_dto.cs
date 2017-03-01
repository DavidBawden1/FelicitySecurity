﻿using System.Collections.Generic;


namespace FelicitySecurity.Core.DataTransferObjects
{
    /// <summary>
    /// The Faces Dto transfers all members faces data and the member who owns them
    /// </summary>
    public class Faces_dto
    {
        public int FaceID { get; set; }
        public byte[] MemFace0 { get; set; }
        public byte[] MemFace1 { get; set; }
        public byte[] MemFace2 { get; set; }
        public byte[] MemFace3 { get; set; }
        public byte[] MemFace4 { get; set; }
        public byte[] MemFace5 { get; set; }
        public byte[] MemFace6 { get; set; }
        public byte[] MemFace7 { get; set; }
        public byte[] MemFace8 { get; set; }
        public byte[] MemFace9 { get; set; }
        public byte[] MemFace10 { get; set; }
        public byte[] MemFace11 { get; set; }
        public byte[] MemFace12 { get; set; }
        public byte[] MemFace13 { get; set; }
        public byte[] MemFace14 { get; set; }
        public byte[] MemFace15 { get; set; }
        public byte[] MemFace16 { get; set; }
        public byte[] MemFace17 { get; set; }
        public byte[] MemFace18 { get; set; }
        public byte[] MemFace19 { get; set; }
        public byte[] MemFace20 { get; set; }
        public int MemID { get; set; }

        public virtual IEnumerable <Members_dto> MembersFaces { get; set; }
    }
}