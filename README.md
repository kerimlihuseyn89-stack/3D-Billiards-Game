# 3D Billiards Game

Unity 3D bilardo oyunu için başlangıç paketi.

Özellikler:
- Tek oyunculu mod
- Aynı bilgisayarda 2 oyuncu modu
- Yapay zeka rakip modu
- Skor takibi
- Turn mantığı
- Top fizik ve çubuk kontrolü

## Proje yapısı
- Assets/Scripts/Billiards
- Assets/Scripts/UI

## Unity'de kullanımı
1. Unity Hub üzerinden yeni bir 3D proje oluşturun.
2. Bu klasör yapısını `Assets` içine taşıyın.
3. Bir sahne oluşturun.
4. Bir `GameManager` nesnesi ekleyin.
5. Masa, beyaz top ve 15 topu sahneye yerleştirin.
6. `CueController` bileşenini beyaz topa ekleyin.
7. `GameHUDController` ve `MainMenuController` scriptlerini UI elemanlarına bağlayın.

## Temel akış
- Ana menüden oyun modu seçilir.
- `GameManager.StartGame(mode)` çağrılır.
- Sırası gelen oyuncu vuruş yapar.
- Toplar ceplere girince skor güncellenir.
- Oyuncu geçişi `SwitchTurn()` ile yapılır.
- Eğer oyun modu `VsAI`, sıra AI'ya gelir.

## Not
Bu proje Unity için hazır başlangıç çerçevesidir. Gerçek 3D masa, top prefab'ları ve sahne düzeni için ekstra scene kurulumu gerekir.
