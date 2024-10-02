 Model Oluşturma
Musician Modeli: Müzisyen verilerini temsil eden bir model oluşturuldu. Model, Id, Name, Profession, ve FunFact alanlarını içeriyor.

MusiciansController: CRUD işlemlerini yönetmek için bir API controller sınıfı oluşturuldu.

Get (Tüm Müzisyenleri Getir): GET /api/musicians ile tüm müzisyenlerin listesini döndürdü.

Get (Tüm Müzisyenleri Getir): GET /api/musicians ile tüm müzisyenlerin listesini döndürdü.


[HttpGet]
public ActionResult<IEnumerable<Musician>> GetAllMusicians()
{
    return Ok(musicianList);
}
Get (Belirli Müzisyeni Getir): GET /api/musicians/{id} ile belirli bir müzisyeni ID'sine göre döndürdü.


[HttpGet("{id}")]
public ActionResult<Musician> GetMusician(int id)
{
    // Müzisyeni bulma kodu
}
Post (Yeni Müzisyen Ekle): POST /api/musicians ile yeni bir müzisyen eklemek için kullanıldı.


[HttpPost]
public ActionResult<Musician> CreateMusician([FromBody] Musician newMusician)
{
    // Müzisyeni listeye ekleme kodu
}
Put (Müzisyen Güncelle): PUT /api/musicians/{id} ile mevcut bir müzisyeni tamamen güncellemek için kullanıldı.


[HttpPut("{id}")]
public ActionResult UpdateMusician(int id, [FromBody] Musician updatedMusician)
{
    // Müzisyeni güncelleme kodu
}
Patch (Kısmi Güncelleme): PATCH /api/musicians/{id} ile belirli bir alanı (örneğin, FunFact) güncellemek için kullanıldı.


[HttpPatch("{id}")]
public ActionResult PatchMusician(int id, [FromBody] JsonPatchDocument<Musician> patchDoc)
{
    // JSON patch uygula kodu
}
Delete (Müzisyen Sil): DELETE /api/musicians/{id} ile belirli bir müzisyeni silmek için kullanıldı.



[HttpDelete("{id}")]
public ActionResult DeleteMusician(int id)
{
    // Müzisyeni silme kodu
}
4. Arama İşlemi
Search API: GET /api/musicians/search?name={name} ile müzisyenleri isme göre aramak için bir API oluşturuldu.


[HttpGet("search")]
public ActionResult<IEnumerable<Musician>> SearchMusician([FromQuery] string name)
{
    // İsimle arama kodu
}
5. Validation İşlemleri
Müzisyen ekleme ve güncelleme işlemleri sırasında model doğrulama için gerekli Data Annotations eklendi.


[Required(ErrorMessage = "Name is required.")]
public string Name { get; set; }
Sonuç
Bu projede, müzisyen verilerini yönetmek için bir Web API oluşturdum. CRUD işlemleri ile müzisyen ekleme, güncelleme, silme ve arama gibi işlemler gerçekleştirildi. Ayrıca, JSON Patch ile kısmi güncellemeler ve model doğrulama da eklendim.

