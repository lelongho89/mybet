using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Teams
{
    [Table("AppTeams")]
    public class Team : Entity
    {
        public const int MaxNameLength = 50;
        public const int MaxFlagLength = 255;
        public const int MaxFifaCodeLength = 3;
        public const int MaxEmojiLength = 7;
        public const int MaxEmojiStringLength = 2;

        public virtual int? TenantId { get; set; }

        [MaxLength(MaxNameLength)]
        public virtual string Name { get; set; }
        /// <summary>
        /// Url of flag.
        /// </summary>
        [MaxLength(MaxFlagLength)]
        public virtual string Flag { get; set; }

        [MaxLength(MaxFifaCodeLength)]
        public virtual string FifaCode { get; set; }

        [MaxLength(MaxEmojiLength)]
        public virtual string Emoji { get; set; }

        [MaxLength(MaxEmojiStringLength)]
        public virtual string EmojiString { get; set; }

        public Team()
        {
        }
        public Team(int? tenantId, string name, string flag, string fifaCode, string emoji, string emojiString)
        {
            this.TenantId = tenantId;
            this.Name = name;
            this.Flag = flag;
            this.Emoji = emoji;
            this.EmojiString = emojiString;
        }
    }
}
