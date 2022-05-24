using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpeechConverter : MonoBehaviour
{
    private LinkedList<Dictionary<string, string>> SectionsLinkedList;
    public Queue<string> people, messages;

    private Dictionary<string, string> Section1, Section2, Section3, Section4, Section5, Section6, Section7;
    public void Awake()
    {
        messages = new Queue<string>();
        people = new Queue<string>();
        SectionsLinkedList = new LinkedList<Dictionary<string, string>>();


        switch (PlayerPrefsOperations.Instance.GetData().language)
        {
            case "Eng":
                EngLanguage();
                break;
            case "Tr":
                TrLanguage();
                break;
            case "Gr":
                GermanLanguage();
                break;
        }
        
        //Speeches
        SectionsLinkedList.AddFirst(Section1);
        SectionsLinkedList.AddLast(Section2);
        SectionsLinkedList.AddLast(Section3);
        SectionsLinkedList.AddLast(Section4);
        SectionsLinkedList.AddLast(Section5);
        SectionsLinkedList.AddLast(Section6);
        SectionsLinkedList.AddLast(Section7);
    }

    private void EngLanguage()
    {
        Section1 = new Dictionary<string, string>
        {
            {"TargetKillNumber","1"},
            {"FoodShop", "Welcome my lady. I am Donald. This is the food shop that provides foods to empower your energy.I provides foods every certain seconds.You can increase production speed with improve button.Thanks for your visitation lady."},
            {"BestFriend", "Hello my friend,I am Angela. We've found you yesterday night at the forest. You were hurt from your head. And we found some people who were died, I think they were your family, I am sorry for that.Actually, I am single and you can stay at my home.I am sure you will love this cute town."},
            {"Warrior", "Hi! My name is Jack.And i am the best warrior of this town. I am responsible from protection of this town. If you have war skills ,no doubt that there  will be competition between us. aHahah."},
            {"Homeless", "Hi lady. I am a homeless in this town. But my home is nature. If you need , I can be your eyes and ears on outside. My name is Peter.Nice to meet you lady."},
            {"Witch", "Hi small girl, I am Maleficent ! I have been waiting for long time to see you, I am the wicth of this town. I can see your future already. I will be with you in this mission. I connect with gods, and I will give you signals coming from them!"},
            {"Priest", "Hi lady, my name is Bernand, I bury to all deads in this town. You can learn your total kill number from me. Nice to meet you lady."}
        };
         Section2 = new Dictionary<string, string>
        {
            {"TargetKillNumber","5"},
            {"Warrior", "There are 10 monster , we have to kill them all. This is a opportunity for good compatition. Both you and me will kill 5 monsters. Lets learn who is going to finish mission first. "},
            {"Witch", "Hi crazy girl ! I can see your tiredness. Do not be afraid of these symptoms, thats normal. " +
                      "Your energy is little low for new war.I have two suggestions to handle with this.First one is my special elixir.Click my home and you can go spirit realm and steal their foods and gain health.Other suggestion is wait for new foods from our town food shop and eat from there."}
        };
         Section3 = new Dictionary<string, string>
        {
            {"TargetKillNumber","4"},
            {"Witch" , "My lady , long time no see. Congrats for your victories. I have both good and bad news for you. The good one is that there are one person who gave his heart for you. He started to love you but i can not see his name.The bad one is that bad souls did not like that you killed some monsters.So they prepared to dragon army that includes 4 dragons for you, be ready!"}
        };
         Section4 = new Dictionary<string, string>
        {
            {"TargetKillNumber","1"},
            {"Warrior" , "Hello lady, actually I dont know how i can say that ... At first sight you took my heart, I love you. And I can't focus my wars well.I think you every minutes every seconds. To buck up my ideas , I will leave from here for short time. Besides, maybe you can think about my these ideas."},
            {"Witch" , "Hello little girl! I smell bad news in the air these days, you may receive news that may upset you emotionally. Meanwhile, except for the 4 dragon monsters you killed, the evil spirits will send one of your strongest demons, kill him and the victory is yours."}
        };
         Section5 = new Dictionary<string, string>
        {
            {"TargetKillNumber","5"},
            {"BestFriend" , "My dear friend, welcome , you look so tired please rest little bit. Have you heard news ? The best warrior of the town Jack was killed by unknown entities at the bounds of town. All town is sad for him. But there is ony one person who knows killers of jack. He is homeless Peter.If you want, you can learn from him."},
            {"Homeless" ,  "I've been waiting for you, my lady. I saw Jack before he died and he wanted me to tell you something important. He said that the person who lured you and your family here with the spells he cast is the witch Maleficent and killed your family by uniting with the evil spirits."},
            {"CONTINUE" ,  "You can kill the demons that cooperate with him by going to war, but your strength is not enough to defeat the witch of the village yet, you need help. You can only defeat magic with knowledge."},
            {"Wicth","Hello my lady! You're a little nervous. You shouldn't be so angry with your enemies, I'm on your side and we'll take over this place together!"}

        };
         Section6 = new Dictionary<string, string>
        {
            {"TargetKillNumber","8"},
            {"Wicth","I am sorry for you, I know that you loved him as well. You cleaned all bad souls in the town. I saw something in magic ball. If you kill new army that contains different type of 3 bad souls. There are 15 monsters in army.If you win 15 monster, you will gain new land(map) that contains wiseman's house, this wiseman can be helpful for us with his knowladge about wars. And this new map has a lake. You will expand our town perfect."}
        };
         Section7 = new Dictionary<string, string>
        {
            {"TargetKillNumber","0"},
            {"Witch","You are the best warrior that I know. You have expanded our map you can visit there. And you gain new perfect wiseman in this map. We will change all world with you."},
            {"Wiseman","Hi small girl, I am new here. Do you want to learn something from me. I am here to share my knowladge. A knowledgeable people resemble a candle, they dont lose their brightness when they ignite other candles.Click my house at 3th map. "}
        };
    }

    private void TrLanguage()
    {
        Section1 = new Dictionary<string, string>
        {
            {"TargetKillNumber","1"},
            {"BAKKAL", "Hoş geldiniz leydim. Ben Donald. Burası enerjinizi güçlendirecek yiyecekler sağlayan yiyecek dükkanıdir.Bu haritada bulundugunuz surece belirli saniyede bir yiyecek uretirim. İyileştirme düğmesi ile üretim hızını artırabilirsiniz.Tekrar beklerim."},
            {"DOSTUMUZ", "Merhaba arkadaşım, ben Angela. Seni dün gece ormanda bulduk. Başından yaralıydın. Ve bazı ölü insanlar bulduk, sanırım ailenden kişiler. Bunun için üzgünüm .Benim kocam savaşçıydı ve geçen ay canavarlar tarafından öldürüldü şuan hamileyim ve yalnızım ve biraz korkuyorum benimle kalır mısın ? Bu şirin kasabayı seveceğine eminim."},
            {"SAVASCI", "Merhaba! Benim adım Jack. Ve ben bu şehrin en iyi savaşçısıyım. Bu şehri korumayı vazifem bilirim. Savaş yeteneğin varsa, aramızda rekabet olacağından şüphe yok. Ahahhha zevkli olacak.Görüşmek üzere leydim."},
            {"EVSIZ", "Merhaba leydim. Ben bu kasabada evsizim. Benim evim doğadır, sokaklarda büyüdüm ve bunu seviyorum. İhtiyacınız olursa dışarda gözünüz kulağınız olabilirim. Benim adım Peter. Tanıştığımıza memnun oldum leydim."},
            {"CADI", "Merhaba küçük kız, ben Maleficent ! Ben bu kasabanın cadısıyım. Topraklarimiza katacagin yeni topraklari simdiden gorebiliyorum.Tanrılarla bağlantı kurarım, sana onlardan gelen sinyalleri veririm!"},
            {"RAHIP", "Merhaba hanımefendi, benim adım Bernand, bu kasabadaki tüm ölüleri gömüyorum. Kralin istegi uzerine her defnetmeyi kayit altina aliriz, istediginiz zaman bu istatistikleri sizinle paylasabilirim. Kiliseye gelmeniz yeterli olacaktir."}
        };
        Section2 = new Dictionary<string, string>
        {
            {"TargetKillNumber","5"},
            {"CADI", "Merhaba çılgın kız! Yorgunluğunu görebiliyorum. Bu belirtilerden korkma, normaldir ancak yeni savaş için enerjin biraz düşük. Bununla baş etmen için iki önerim var. Birincisi benim özel iksirim.Evime tıkla ve ruhlar alemine gidip onların yiyeceklerini çal ve sağlık,enerji kazan. Diğer öneri kasabamızdaki yiyecek dükkanından yeni yiyecekleri beklemek"},
            {"SAVASCI", "Kasabada 10 canavar görüldü. Hepsini öldürmemiz gerekiyor. Bu iyi bir yarışma için bir fırsat. Hem sen hem ben 5 er canavar öldüreceğiz. Önce görevi kimin bitireceğini öğrenelim. Unutma cadinin gonderdigi ruhlar alemindeki olumler sayilmaz !"}
        };
        Section3 = new Dictionary<string, string>
        {
            {"TargetKillNumber","4"},
            {"CADI" , "Leydim uzun zamandır görüşmüyoruz. Zaferleriniz için tebrikler. Size hem iyi hem de kötü bir haberim var. İyi olan şu ki, size kalbini veren bir kişi var. Seni sevmeye başlamış, ama sihirli kürede adını göremiyorum. Kötü olan haberimse, kötü ruhlar senin bazı canavarları öldürmenden hoşlanmadılar. Bu yüzden senin için 4 ejderha içeren ejderha ordusunu hazırladılar, hazır ol!"},
            {"SAVASCI", "Evet gerçekten iyi bir savaşçısın beni yendin. Yeni orduyla savaşa gidiyormuşsun kendine dikkat et!"}
        };
        Section4 = new Dictionary<string, string>
        {
            {"TargetKillNumber","1"},
            {"SAVASCI" , "Merhaba leydim, aslında bunu nasıl söyleyeceğimi bilmiyorum... Sanırım sizden hoşlanıyorum.Ancak artık savaşlarıma iyi odaklanamıyorum. Sanıyorum her dakika her saniye sizi düşünüyorum. Fikirlerimi pekiştirmek için kısa bir süre buradan ayrılacağım. Ayrıca, belki sizde size karşı olan bu duygularımı düşünme fırsatı bulmuş olursunuz."},
            {"CADI" , "Merhaba küçük kız ! Bu günlerde havada kötü haberlerin kokusunu alıyorum,duygusal olarak seni ,üzebilecek haberler alabilirsin. Bu arada, öldürdüğün 4 ejderha canavar hariç, kötü ruhlar en güçlü şeytanlarından birini gönderecek, onu öldür ve zafer senin."}
        };
        Section5 = new Dictionary<string, string>
        {
            {"TargetKillNumber","5"},
            {"DOSTUMUZ" , "Sevgili dostum hoşgeldin çok yorgun görünüyorsun biraz dinlen lütfen. Haberi aldın mı? Kasabanın en iyi savaşçısı Jack kasaba sınırında bilinmeyen varlıklar tarafından öldürülmüş. Bütün kasaba ona üzülüyor. Ama Jack'in katillerini bilen bir kişi olabilir. Evsiz Peter. İstersen ondan öğrenebilirsin."},
            {"EVSIZ" ,  "Leydim sizi bekliyordum Jacki ölmeden önce gördüm ve size önemli bir şey söylememi istedi. Ailenizle sizi buraya yaptığı büyülerle çeken kişinin cadı Maleficent olduğunu ve ailenizi kötü ruhlarla bir olup öldürdüğünü söyledi, bu toprakların sahibi olmak istiyormuş ancak yeterli savaş gücü olmadığı için sizin gücünüzden yararlanma amacındaymış, cadı bunları öğrendiği için onu öldürtmüş"},
            {"CONTINUE" ,  " Onunla işbirliği yapan şeytanları savaşa giderek öldürebilirsiniz ancak henüz gücünüz köyün cadısını yenmeye yetmez, yanınıza yardımcı gerekiyor, belli düşman yenerek doğumuzdaki laxes haritasını açabilirseniz orada bilge adam olduğunu duymuştum, onunla bir olun. Büyüyü ancak bilgi ile yenebilirsiniz."},
            {"CADI" ,  " Selamlar leydim ! Biraz sinirli gözüküyorsun. Düşmanlarına bu kadar sinirlenmemelisin ben senin yanındayım buraları ikimiz beraber ele geçireceğiz!"}
        };
        Section6 = new Dictionary<string, string>
        {
            {"TargetKillNumber","8"},
            {"CADI","Merhaba leydim.Sihirli Kürede artık herşey daha net, kötü tanrılar seni yenmek için bir araya gelmeye başladı 8 kişilik yeni karisik bir ordu hazırladılar eğer bu tanrıları yenmeyi başarabilirsen yeni toprak ve bilge adam topraklarımıza katılacak.Başar şu işi..."}
        };
        Section7 = new Dictionary<string, string>
        {
            {"TargetKillNumber","0"},
            {"CADI","Sen tanıdığım en iyi savaşçısın. Haritamızı genişlettin, orayı ziyaret edebilirsin. Ve bu haritada yeni bir mükemmel bilge adam kazandın. Seninle tüm dünyayı değiştireceğiz.Artık seçilmiş kişinin sen olduğuna şüphem yok!"},
            {"BILGE ADAM","Merhaba küçük kız, ben burada yeniyim. Benden bir şey öğrenmek ister misin ? Bilgilerimi paylaşmak için buradayım. Bilgili insan muma benzer, başka mumları tutuşturduğunda parlaklığından bir şey kaybetmez. 3.haritada evime tikla."}
        }; 
    }
    private void GermanLanguage()
    {
        
        Section1 = new Dictionary<string, string>
        {
            {"TargetKillNumber","1"},
            {"Gemischtwarenladen", "Willkommen, meine Damen.Ich bin Donald( Mien Name ist Donald, Ich heiße Danald) Dies ist der Lebensmittelladen, der Lebensmittel liefert, um Ihre Energie zu steigern. Solange Sie sich auf dieser Karte befinden, werde ich einmal pro Sekunde Lebensmittel produzieren. Siz können die Produktionsgeschwindigkeit mit der Heiltaste. Ich warte nochmal."},
            {"Enger Freund", "Hallo Freund, ich bin Angela. Wir haben dich letzte Nacht im Wald gefunden. Du wurdest am Kopf verletzt. Und wir haben einige tote Menschen gefunden, ich glaube, Ihre Familienmitglieder. Das tut mir leid. Mein Mann war ein Krieger und wurde letzten Monat von Monstern getötet. Ich bin jetzt schwanger und ich bin allein und ich habe ein bisschen Angst. Willst du bei mir bleiben? Ich bin sicher, Sie werden diese malerische Stadt lieben."},
            {"Kämpfer", "Hallo! Ich heiße Jack. Und ich bin der beste Krieger in dieser Stadt. Ich betrachte es als meine Pflicht, diese Stadt zu beschützen. Wenn Sie die Fähigkeit des Krieges haben, gibt es keinen Zweifel, dass es einen Wettbewerb zwischen uns geben wird. Ahhhha, das wird ein Spaß. Bis bald, meine Dame."},
            {"Obdachlos", "Hallo, Lady. Ich bin obdachlos in dieser Stadt. Mein Zuhause ist die Natur, ich bin auf der Straße aufgewachsen und ich liebe es. Ich kann draußen deine Augen und Ohren sein, wenn du es brauchst. Mein Name ist Peter. Schön, dich zu treffen Sie, meine Dame."},
            {"Hexe", "Hallo kleines Mädchen, ich bin Maleficent! Ich habe lange darauf gewartet, dich zu sehen, ich bin die Hexe dieser Stadt. Ich kann deine Zukunft schon sehen. Ich werde bei dieser Mission mit dir sein. Ich verbinde mich mit den Göttern, ich gebe dir Signale von ihnen!"},
            {"Priester", "Hallo Ma'am, mein Name ist Bernand, ich begrabe alle Toten in dieser Stadt. Ihre Gesamtzahl an Kills können Sie von mir erfahren. Schön, Sie kennenzulernen, Ma'am"}
        };
        Section2 = new Dictionary<string, string>
        {
            {"TargetKillNumber","5"},
            {"Hexe", "Hallo verrücktes Mädchen! Ich sehe deine Müdigkeit. Haben Sie keine Angst vor diesen Symptomen, das ist normal, Ihre Energie ist etwas niedrig für den neuen Kampf. Ich habe zwei Vorschläge für den Umgang damit. Das erste ist mein besonderes Elixier. Klicke auf mein Haus und gehe in das Reich der Geister, stiehl ihr Essen und erhalte Gesundheit und Energie. Ein anderer Vorschlag ist, auf neue Lebensmittel aus dem Lebensmittelgeschäft in unserer Stadt zu warten und von dort zu essen."},
            {"Kämpfer", "10 Monster wurden in der Stadt gesehen. Wir müssen sie alle töten. Dies ist eine Gelegenheit für einen guten Wettbewerb, mal sehen, wer besser ist. Sowohl Sie als auch ich werden 5 Monster töten. Lassen Sie uns herausfinden, wer die Aufgabe zuerst erledigt."}
        };
        Section3 = new Dictionary<string, string>
        {
            {"TargetKillNumber","4"},
            {"Hexe" , "Meine Dame, wir haben uns lange nicht gesehen. Herzlichen Glückwunsch zu Ihren Siegen. Ich habe sowohl gute als auch schlechte Nachrichten für Sie. Das Gute ist, dass es einen Menschen gibt, der einem sein Herz schenkt. Er beginnt dich zu mögen, aber ich kann deinen Namen nicht auf der magischen Kugel sehen. Die schlechte Nachricht ist, dass die bösen Geister es nicht mochten, wenn du ein paar Monster tötest. Also haben sie die Drachenarmee mit 4 Drachen für dich vorbereitet, mach dich bereit!"},
            {"Kämpfer", "Ja, du bist ein wirklich guter Kämpfer, du hast mich geschlagen. Du ziehst mit der neuen Armee in den Krieg, pass auf dich auf!"}
        };
        Section4 = new Dictionary<string, string>
        {
            {"TargetKillNumber","1"},
            {"Kämpfer" , "Hallo meine Dame, eigentlich weiß ich nicht, wie ich das sagen soll... Du hast mein Herz auf den ersten Blick, ich liebe dich. Und ich kann mich in meinen Kämpfen nicht gut konzentrieren. Ich schätze jede Minute, jede Sekunde. Ich werde hier kurz weggehen, um meine Ideen zu konsolidieren. Vielleicht können Sie auch diese Ideen von mir berücksichtigen."},
            {"Hexe" , "Hallo kleines Mädchen! Ich rieche in diesen Tagen schlechte Nachrichten in der Luft, Sie können Nachrichten erhalten, die Sie emotional aufregen können. In der Zwischenzeit werden die bösen Geister außer den 4 Drachenmonstern, die Sie getötet haben, einen Ihrer stärksten Dämonen schicken, ihn töten und der Sieg gehört Ihnen."}
        };
        Section5 = new Dictionary<string, string>
        {
            {"TargetKillNumber","5"},
            {"Enger Freund" , "Willkommen, mein lieber Freund, Sie sehen sehr müde aus, bitte ruhen Sie sich aus. Hast du die Nachricht bekommen? Der beste Krieger der Stadt, Jack, wurde von unbekannten Wesen an der Stadtgrenze getötet. Die ganze Stadt tut ihm leid. Aber es könnte jemanden geben, der über Jacks Mörder Bescheid weiß. Obdachloser Peter. Wenn du willst, kannst du von ihm lernen."},
            {"Obdachlos" ,  " Ich habe auf Sie gewartet, Mylady. Ich habe Jack gesehen, bevor er starb, und er wollte, dass ich Ihnen etwas Wichtiges sage. Er sagte, dass die Person, die dich und deine Familie mit seinen Zaubersprüchen hierher gelockt hat, die Hexe Maleficent ist und deine Familie getötet hat, indem sie sich mit den bösen Geistern vereint hat."},
            {"CONTINUE" ,  " Du kannst die Dämonen töten, die mit ihm zusammenarbeiten, indem du in den Krieg ziehst, aber deine Kraft reicht noch nicht aus, um die Hexe des Dorfes zu besiegen, du brauchst Hilfe. Magie kann man nur mit Wissen besiegen."},
            {"Hexe" ,  "Hallo, meine Dame! Du bist etwas nervös. Du solltest deinen Feinden nicht so böse sein, ich bin auf deiner Seite und wir übernehmen diesen Ort gemeinsam!"}
        };
        Section6 = new Dictionary<string, string>
        {
            {"TargetKillNumber","8"},
            {"Hexe","Hallo meine Dame. In der magischen Sphäre ist jetzt alles klarer, die bösen Götter haben begonnen, sich zu versammeln, um dich zu besiegen. Sie haben eine neue 8-köpfige Armee vorbereitet, wenn du diese Götter besiegen kannst, werden sich das neue Land und der weise Mann anschließen unser Land."}
        };
        Section7 = new Dictionary<string, string>
        {
            {"TargetKillNumber","0"},
            {"Hexe","Du bist der beste Krieger, den ich kenne. Sie haben unsere Karte erweitert, Sie können sie dort besuchen. Und Sie haben auf dieser Karte einen neuen perfekten Weisen gewonnen. Mit dir werden wir die ganze Welt verändern, jetzt habe ich keinen Zweifel daran, dass du der Auserwählte bist!"},
            {"Weiser Mann","Hallo kleines Mädchen, ich bin neu hier. Willst du etwas von mir lernen? Ich bin hier, um mein Wissen zu teilen. Ein sachkundiger Mensch ist wie eine Kerze, sie verliert nichts von ihrem Glanz, wenn sie andere Kerzen anzündet."}
        }; 
    }
    
    
    public List<Queue<string>> GetMessages()
    {
        print("here2");
        var iter = SectionsLinkedList.First;
        print(iter);
        for (int i = 0; i < PlayerPrefsOperations.Instance.GetData().section; i++)
        {
            iter = iter.Next;
        }
        print(PlayerPrefsOperations.Instance.GetData().language);   
        foreach (var pair in iter.Value.Where(pair => !pair.Key.Equals("TargetKillNumber")))
        {
            people.Enqueue(pair.Key);
            messages.Enqueue(pair.Value);
        }

        List<Queue<string>> Queues = new List<Queue<string>>();
        Queues.Add(people);
        Queues.Add(messages);
        return Queues;
    }
    
}
