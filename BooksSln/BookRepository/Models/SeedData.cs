using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace BookRepository.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            RepositoryDBContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<RepositoryDBContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                new Book
                {
                    Title = "Magick: Liber ABA, Book 4",
                    Author = "Aleister Crowley",
                    Description = "This book is the introduction, the foundation upon which all further magical work will be based. Its simplicity, clarity and depth is without equal occult literature. The First part of Book " +
                    "Four deals with Yoga in a very sound and methodical manner, stripping it of the mysterious and glitter. Soberly, Crowley describes each step as a technique of mental and/or physical discipline, ultimately " +
                    "resulting in complete control of the will and with this, control of the physical and mental body. Crowley speaks with authority as he is one of the few writers on the subject of Yoga and Magick who has " +
                    "attained Dhyana and Conversation with his Holy Guardian Angel through discipline and ritual practice. The second part of Book Four is an encyclopedia of magical symbolism, the working tools in practical " +
                    "magick. All of the paraphernalia employed in ritual magick are carefully explained in both psychological and mystical terms. The Wand is the will of man, his wisdom, his word, the Cup is man;s understanding," +
                    " the vehicle of grace; the Sword is reason, the analytical faculty of man; and the Pantacle is man's body, the temple of the Holy Ghost. All phenomena are sacraments. Every fact must enter into the Pantacle." +
                    " It is the great storehouse from which the Magician draws. The laws and truths of the accult world which are presented here give the student a sound working knowledge and set him firmly on the path. Book " +
                    "Four is a concise, direct and honest presentation." +
                    "" +
                    "This second revised edition of Crowley's magnum opus features new, more legible typesetting, text corrections based on a previously unseen corrected proof, and the previously unpublished Liber Testis Testitudinis." +
                    "The original Book of the Law was rescanned for this edition, using the latest technology, for the clearest facsimile possible. Edited, annotated, and introduced by Frater Hymenaeus Beta, XI.",
                    Category = "Ceremonial Magic",
                    Paradigm = "Thelema",
                    BookSeller = "Weiser Books",
                },
                new Book
                {
                    Title = "The Book of Thoth: (Egyptian Tarot)",
                    Author = "Aleister Crowley",
                    Description = "Aleister Crowley's The Book of Thoth endures as one of the most definitive volumes on the tarot ever written. This classic text describes the philosophy and use of Aleister Crowley's Thoth " +
                    "Tarot, a deck designed by Crowley and painted by Lady Frieda Harris. The Thoth Tarot has become one of the bestselling tarot decks in the world. It is also one of the most original interpretations of the " +
                    "tarot, incorporating astrological, numerological, Egyptian, and Qabalistic symbolism. While there are many other useful guides to this famous tarot deck, there are no others that explain the deck in its " +
                    "designer's own words. " +
                    "" +
                    "This new facsimile edition of The Book of Thoth is a faithful reproduction of the Samuel Weiser Inc. 1969 edition, which in turn was a facsimile of the original O.T.O.edition printed in 1944.The text is " +
                    "digitally restored, printed on a heavy, coated stock, and features revised color plates and black and white illustrations of the Thoth Tarot based on new photography of the original art, courtesy of the " +
                    "O.T.O.and The Warburg Institute.The book text block is smyth sewn, with a rounded back, and headbands.Printed endpaper reproduces the Egyptian motif from the board covers of the 1944 edition.The cover is " +
                    "quality cloth over boards with gold stamping on the spine, and is wrapped with a jacket which again features updated art while matching the original design.Weiser Books takes pride in the release of this " +
                    "new hardcover reprint on the event of our 60th anniversary in publishing. " +
                    "" +
                    "The Book of Thoth is an indispensable companion to the deck and the most authoritative and reliable guide to the Tarot in the New Aeon. --Hymenaeus Beta, Frater Superior, O.T.O. " +
                    "" +
                    "Replaces ISBN 9780877282686",
                    Category = "Tarot",
                    Paradigm = "Thelema",
                    BookSeller = "Weiser Books",
                },
                new Book
                {
                    Title = "Wicca: A Guide for the Solitary Practitioner",
                    Author = "Scott Cunningham",
                    Description = "Cunningham's classic introduction to Wicca is about how to live life magically, spiritually, and wholly attuned with nature. It is a book of sense and common sense, not only about magick, but " +
                    "about religion and one of the most critical issues of today: how to achieve the much needed and wholesome relationship with our Earth. Cunningham presents Wicca as it is today: a gentle, Earth-oriented " +
                    "religion dedicated to the Goddess and God. Wicca also includes Scott Cunningham's own Book of Shadows and updated appendices of periodicals and occult suppliers.",
                    Category = "Paganism",
                    Paradigm = "Wicca",
                    BookSeller = "Llewellyn Publications",
                },
                new Book
                {
                    Title = "Wiccan Beliefs & Practices: With Rituals for Solitaries & Covens",
                    Author = "Gary Cantrell",
                    Description = "Modern Wicca is a vibrant, uplifting nature religion practiced by hundreds of thousands of people in the United States alone. But wearing witchy jewelry and casting a few spells does not make" +
                    " one a witch, for Wicca is a lifestyle and those who walk its path have solemnly dedicated themselves to the service of the Goddess and God. " +
                    "" +
                    "Wiccan Beliefs and Practices was written for the solitary witch or non - traditional small coven.Written by a Wiccan High Priest and retired aerospace engineer, Wiccan Beliefs & Practices includes crucial " +
                    "information not found in other introductory Wiccan books, including:" +
                    "" +
                    "Ethics of a Witch, including the Code of Chivalry" +
                    "How to write and develop your own spells and rituals" +
                    "The physically - challenged Witch" +
                    "Out of the broom closet: is it right for you?" +
                    "Know your rights: the legal protection of Wicca as a legitimate religion" +
                    "" +
                    "Author Gary Cantrell speaks from personal experience with Wiccans of all ages and degrees of physical ability, bringing you an earnest examination of modern Wiccan beliefs and a practical guide to the Craft " +
                    "of the Wise.",
                    Category = "Paganism",
                    Paradigm = "Wicca",
                    BookSeller = "Llewellyn Publications",
                },
                new Book
                {
                    Title = "Queen of Hell",
                    Author = "Mark Alan Smith",
                    Description = "The First Book of the Trident Trilogy and Primal Craft Grimoires, Queen of Hell is the consummate reunification of Ceremonial Magick and Witchcraft. Direct contact with the Goddess Hecate is " +
                    "achieved through performance of rites within this tome. Devotees will find their own depth and level of experience allowing them to step into the Primal Current. Through ritual self-dedication, possession " +
                    "and sexual union, the Goddess guides the soul in evolution. This is Witchcraft! Rituals for the formation of the Qlippothic Mirror, Spirit Pots, Pacts of the Toad Rite and communication with Wolfen Spirits " +
                    "are all given. The Path of Hecate is followed in spritual evolutin and empowerment, ulitmately leading to the Phoenix Rite in which - for those deemed ready - the Gates of the Abyss are opened in the Dark " +
                    "Lake Crossing.",
                    Category = "Paganism",
                    Paradigm = "Witchcraft",
                    BookSeller = "Primal Craft Occult Publications",
                },
                new Book
                {
                    Title = "Saturn Rising",
                    Author = "J.T. Kirkbride",
                    Description = "Saturn Rising is a talismanic grimoire promoting the veneration, worship and pursuit of death in all its formless glory, whether manifesting as death-as-ending, death-as-change, or death-as-rebirth" +
                    ". While it may appear that creation and destruction are the two ends of a very broad spectrum, this work serves to guide the reader to the understanding that they are but two sides of a very thin coin, " +
                    "remaining forever inseparable. In order to create a work of art, we must first destroy a virgin canvas. Before we are able to compose a piece of music, we must likewise destroy the sanctity of silence. " +
                    "When we choose to create more Life for ourselves, we must also understand how - and what it means - to Die." +
                    "" +
                    "Saturn Rising is a fundamentally different text to most every esoteric publication to date.Its extensive use of dependable and reproducible modern science as a device for conceptual metaphor, in addition to " +
                    "its fervent championing of the Scientific Method remind us of those two short statements which grace the Equinox journal of the Argenteum Astrum: The Method of Science --- The Aim of Religion.While some " +
                    "may regard as suspicious the inclusion of a highly - scientific foundation within a talismanic grimoire, its purpose is by no means to attempt to explain - away any spiritual experience in terms of " +
                    "psychological - or other - wholly - physical phenomena.Rather, it is to provide a common foundation and a base of universal definitions by which spiritual experiences may be communicated, systematically " +
                    "evaluated, and if possible, even reproduced. Surely, there can be no better model to adopt than that of modern science if one wishes to attempt the reproduction - and study - of spiritual, mystical and " +
                    "paranormal phenomena." +
                    "" +
                    "The greatest benefit to the use of science in a work such as Saturn Rising is the great deal of conceptual standardization, and incremental advancement made possible. Whereas once, religious metaphor was " +
                    "used to explain even the most elementary physical principles we see all around us in the natural world, and which we now take for granted.Over the course of time, our understanding of Nature has progressed " +
                    "to such a degree that we are now able to reverse this practise, and instead use scientific examples of well - known phenomena to classify our many varied experiences, allowing for the systematic exploration" +
                    " thereof.When dealing with such potentially -volatile concepts as death - worship and the integration of the death-current into our existing magical and religious systems, it is useful beyond measure to be " +
                    "able to approach -and adopt - these often - dangerous ideas in a manner, and at a pace best suited to ourselves alone. This is perhaps the most advantageous manifestation of all those which result from the " +
                    "founding of death - cultism upon a firm bedrock of scientific methodology. " +
                    "" +
                    "The first section of Saturn Rising -entitled Theory - concerns itself with exploring the three principal manifestations of death energies; that is, death as an ending, as change, and as a rebirth.The " +
                    "fundamental nature of death itself is considered from the perspective of the author as a medical professional, the social phenomenon known as the Seven-Year Itch, and other social aberrations such as a " +
                    "disproportionate propensity for suicide - among numerous other topics - are treated with great clarity, depth of thought, and with two key concepts held at the fore.Firstly, how the consideration of these " +
                    "theoretical subjects may benefit either the understanding, or the application of death - cultism by the reader, so as not to waste their time and energy on trivia or minutiae.Secondly, how the cosmic " +
                    "archetype of Saturn and its associated correspondences ultimately tie -in to the concepts at hand, and what it is that Saturn may be able to teach us regarding death in each of its forms, throughout each " +
                    "of the chapters of this section." +
                    "" +
                    "Did you know that Tobacco is the plant most directly associated with Saturn ? As is the elemental metal Lead, while Saturn itself is related to both Death, and the passage of Time. What most people do not " +
                    "know, however, is that a number of commercial American tobacco crops are fertilized with material in which extremely high concentrations of a radioactive version of the lead metal may be found.All we need do" +
                    " is add a little time, and it's little wonder that cigarettes are related to so many cancer deaths. At each step of the way, there is a direct and undeniable link to both death in some form, and Saturn as " +
                    "the archetypal representative thereof, while associations such as this prove themselves to be a recurrent theme throughout the entirety of this work, both quite by accident and yet with an almost " +
                    "unbelievable frequency. " +
                    "" +
                    "The second section of Saturn Rising -entitled Practise - deals with the real - world application of established Western Ceremonial Magical techniques, the standardization of fundamental magical definitions " +
                    "using scientific methodology, the construction and employment of ritual tools, the nuances of magical timing, the overriding procedure behind the modified Western method of ritual magic as presented in this " +
                    "text, and a secular, non - ceremonial form of magic which has heretofore seen mention in various books of Chaos -and of course, other -postmodern magical systems, yet not been fully explained in practise, " +
                    "nor had its fundamental workings hypothesized about to any great degree.Both of these oversights have been addressed in Saturn Rising, and a not-only complete, but also eminently workable form of creative " +
                    "magic -similar in some respects to the sigil magic techniques of Austin Osman Spare and Kenneth Grant -comes to the fore as a unique and incredibly flexible means by which future events may be easily molded " +
                    "and shaped to an incredible degree of acuity." +
                    "" +
                    "Finally, Saturn Rising closes with a selection of rituals designed to initiate the practitioner into the current of Saturnian death - cultism.The focus of these rituals is to provide a solid framework by " +
                    "which the sole magician may engage with, manipulate to their own ends, and apply in whatever fashion they see fit the energies of death, including integration into their own system(s) of magic and " +
                    "spirituality. The rites themselves include techniques by which gateways into the spiritual realm -including those areas in which angelic and demonic entities are said to reside - may be opened, allowing for " +
                    "a greater degree of contact with spirits, a deeper immersion within the subjective experience of ritual evocation, and the control of non - conscious energy for all manner of interesting ends.The concluding " +
                    "ritual provides the reader with the means to ritually charge objects with spiritual energy, or even invite the habitation of a spirit - again, including angels and demons - within the object in question, " +
                    "usually with the understanding that the particular spirit employed will continue to influence the magician's life in a positive way, so long as the object sees frequent personal contact. It is for this " +
                    "reason that enchanted jewelry is most commonly encountered, but it must be understood that this situation is a mutual exchange and not one of spiritual dominance, or the use of magical force against the will" +
                    " of an entity." +
                    "" +
                    "Overall, Saturn Rising is a unique grimoire which aims to further the conscious acceptance and understanding of the death current, even to the point of venerating this ubiquitous and universal element within" +
                    " the natural world, of which the spiritual and magical realms are but a small part.",
                    Category = "Ceremonial Magic",
                    Paradigm = "Death Magic",
                    BookSeller = "Aeon Sophia Press",
                },
                new Book
                {
                    Title = "Thursakyngi Volume 1 - The Essence of Thursian Sorcery",
                    Author = "Ekortu",
                    Description = "Volume I is the first book of in this set of Thursatru Grimoires and presents outline for the foundation in Thursatru Tradition. This book will be for the Seekers of the Giant’s Path; " +
                    "those that seek the ancient wisdom through the experience and Illumination of the forces of Chaos. The main topics in this series of books will focus spiritual workings, rune mysteries, practical sorcery, " +
                    "High Thursian Magic, religious aspects and worship of the divinity of Nifl and Muspell, interpretation and understandings of the Norse mythology and gigantology, Hel-workings, synthesis of pre-Christian " +
                    "Norse, gnostic and LHP perspectives, lycanthropy and different forms of shape-shifting within the Hamr-workings and much more, manifesting a practical path of the religio-sorcerous cult of the titanic " +
                    "forces referred to as Thurses. " +
                    "" +
                    "Thursatru is a new progeny of the old pre - Christian Norse religion, mythology and gigantology, serving here to manifest the impulses striving to overthrow the limitations " +
                    "of cosmic creation.The first book will be an offering and dedication to the primordial powers beyond the ordered universe.May the Flames of Surtr be the essence of this forthcoming book and the Poisonous " +
                    "Blood of Aurgelmir flow as and through its ink.",
                    Category = "Thursatru",
                    Paradigm = "Norse",
                    BookSeller = "Ixaxaar",
                },
                new Book
                {
                    Title = "Thursakyngi Volume 2 - Loki",
                    Author = "Ekortu",
                    Description = "‘LOKI’ is the second volume in the Þursakyngi series and a grimoire focused on the Sorcerous Praxis of the Thursatru Tradition, a book meant to be a guide for the Thursatruar towards and " +
                    "through the initiatory stages of the Cult of Loki. " +
                    "" +
                    "The grimoire opens with the chapter ‘Þursbók Loka’ which divulges a Thursian Perspective on Loki, as it is perceived according to the gnosis of the author." +
                    "It is as such intended to illuminate and bring forth the hidden virtues, aspects, and inner essence of Loki. " +
                    "" +
                    "The anti - cosmic gnosis received from Mighty Loki within this chapter teaches about the esoteric implications of some of the mythological descriptions of Loki, presented here in a new light, together with " +
                    "his corresponding sacred names and epithets used within the Thursatru Tradition, including also an explanation of his aspect as Útgarðaloki; and other corresponding aspects and virtues of contextual " +
                    "relevance. " +
                    "" +
                    "The following chapter ‘Fjölkyngisbók’ continues with an assemblage of texts which are meant to prepare the Thursatruar for the Initiatory Workings, with subjects such as Trollskapr, where the general " +
                    "umbrella term Troll is discussed as being, within this specific context of the work presented, descriptive of those that are carriers of the Black Flame, belonging to the Thursian Bloodline.Other topics " +
                    "discussed concern the proper way to Cleanse, Consecrate, and Empower, Hvergelmisvatn, how to light a magical fire; Knot Magic; how to harvest plant parts, the Runes used in Thursian Sorcery, Runic " +
                    "Numerology, the Disharmonic activation of the Thursian powers of the Runes; the Secret Runes of Loki and Loptr where the runes in His names are read and referred to and understood in the darksome light " +
                    "cast by Loki, Fella Blótspánn where an old divination method has been re - created and personalized to suit the Thursian approach and much more. " +
                    "" +
                    "All this followed by the first chapter on the Sorcerous Workings called ‘Lævateinstaufr’, which guides the Thursatruar in creating and empowering the threefold Lævateinn Fetish and its Mound Throne, to be " +
                    "placed on the Altar of Loki. Book is in fine unread condition. " +
                    "" +
                    "These magical expositions continue with the chapter called ‘Lokastallr’, where instructions concerning how to create the proper Thursian Altar of Loki and its tools, materials, and elements are given. " +
                    "" +
                    "In the succeeding chapter called ‘Þursakyngisbók Loka’ the book continues to describe and explain certain important elements of the Lokian Sorcery, such as the specific incenses, offerings, the fire steel " +
                    "talisman and the fires of Loki and many other implements by which the webs of magic are created, the Thursian spells are cast and the Antagonistic Forces of the Giants reached and employed. " +
                    "" +
                    "The grimoire closes with the chapter ‘Blótbók Loka’, which gives the invocations and prayers of the Thursian Cult, granting so to the reader all that is needed in order to cultivate the Fires of Loki, to " +
                    "burn within and light up the path leading to the hidden essence of the Instigator of the World Fire, through which all shall be made cleansed and freed.",
                    Category = "Thursatru",
                    Paradigm = "Norse",
                    BookSeller = "Ixaxaar",
                },
                new Book
                {
                    Title = "Thursakyngi Volum 3 - Gulveigarbok",
                    Author = "Ekortu",
                    Description = "She is known as the black underworldly crone and giantess of the black anti-cosmic runes and magic, who comes at midnight up from under the ground and walks between houses to visit the " +
                    "practitioners of the black arts (or fjölkunnigr, as they were called), to teach them about the black runes and anti-cosmic magic. She is known as first wife, or mistress of Loki. Her names are many, amongst " +
                    "which the most well-known ones are Gullveig, Heiðr, Aurboða, Angrboða and Hyrrokin. " +
                    "" +
                    "She was looked upon as an evil woman, “illr kona”, and the mother of all trolls, “flagð”, troll being the Old Norse term for malignant and bestial demons, viewed upon as a thurs - kin, which are often " +
                    "dwellers of the forests, mountains and the underworld. " +
                    "" +
                    "Gullveig is a mother - giantess, since she procreated most of the hordes of monsters and wolf - thurses, all of which will gather, fight and triumph during the final day of wrath – Ragna Rök. " +
                    "" +
                    "Her most important ragnarokian children with Loki are Jörmungandr, Fenrir, and Hel.Not only is she a mother - giantess: under the name Heiðr, “the shining one”, she is also the witch goddess, the wielder of " +
                    "the blackest might.She was the brightness crawling out of the abyss and taking form, up through endless darkness, and slithering through the cracking boundries of middle earth.Bright as a shadowless light " +
                    "she came, erect like a burning beam of darksome light she stood, and went forth to those she found receptive for her Wisdom, to instruct them on the unknown and dark arts of the underworlds and beyond.She " +
                    "is the inventor of black magic and runes – the craft and cunning to seduce giants, humans and gods to gain her end. " +
                    "" +
                    "The book explores Gullveig through Old Norse mythology, sagas, Witchcraft & Poetry, which also includes descriptions of related giants and underworldly locations connected to her, such as: Loki, Jørmungandr," +
                    " Fenrir, Hel; Jøtunheimr, Helheimr, Niflheimr, and much more. " +
                    "" +
                    "The Gullveigarbók gives the student a wide overview, explaining the darker side of Norse mythology as a whole, making it a an important work for readers searching for knowledge concerning this before seldom " +
                    "explored aspect of Northern Spirituality. " +
                    "" +
                    "The latter part of the Gullveigarbók book is called Fjølkyngi, witchcraft, and holds the esoteric aspects and praxis of the author’s own witchcraft as connected to the Thursatru Tradition – Þursatrú siðr – " +
                    "and divulges aspects of the author’s magical Gullveig workings.This part of the book also introduces students to how the Gullveig sigils, or bindrunes are to be employed. " +
                    "" +
                    "The book ends with a collection of invocatory and consecratory poetry composed by the author while being inspired by the Spirits as result of his Seta(ecstatic trance work).",
                    Category = "Thursatru",
                    Paradigm = "Norse",
                    BookSeller = "Ixaxaar",
                },
                new Book
                {
                    Title = "Thursakyngi Volume 4 - Svartkonst",
                    Author = "Ekortu",
                    Description = "Þursakyngi IV ‘Svartkonst’ is the first part of a two-part series regarding Swedish sorcery known as svartkonst (black art). This book offers a historical, mythological and folkloric insight " +
                    "in old Swedish folk magical traditions with explanations and a glossary, as well as twenty-four practical bindrunes, called Trollrunor, which are charged and tested according to Swedish svartkonst and our " +
                    "own tradition. They can be quickened and employed by following the instructions that comes with each rune. In line with the Trollrunor, the book also comprises fourteen simpler bindrunes called Tursarnas " +
                    "Vapen, each one representing a sorcerous virtue, which are employed when their empowerments are needed. Their attributes, correspondences and sympathetic links are listed with each rune. In addition to the " +
                    "practical part, customs concerning offerings, periods and days of the year, tincture and incense recipes for cleansing, magical ink formula, and how to make a conjuring wand are included. " +
                    "" +
                    "In the last part of the book, a handful of the most relevant entities(väsen) connected to svartkonst, our Thursian Tradition and the mysteries leading back to the Descendants of the Thurses are explored in " +
                    "a concise but insightful form from the perspective of Swedish folklore, such as the Devil, giants and trolls, and genii loci(such as rån, näckar and tomtar etc.), an account which is meant to give those " +
                    "enticed by svartkonst a strong foundation in the relevant aspects of Swedish folk belief. " +
                    "" +
                    "Swedish Svartkonst(black art or nigromancy) is not equivalent to any imagined form of “pure Swedish pre - Christian magic”, but is instead something that while having emerged from the Old Norse forms of " +
                    "spirituality early on been saturated by Christian influences which successively predominated the folk belief and practical sorcery of Scandinavia. And through this amalgamation of old wisdom with the newer " +
                    "beliefs and knowledge concerning conjurations, magic, alchemy, and medicine the very unique and often transgressive folk magic known as svartkonst was forged.",
                    Category = "Thursatru",
                    Paradigm = "Norse",
                    BookSeller = "Ixaxaar",
                }
            );
                context.SaveChanges();
            }
        }
    }
}