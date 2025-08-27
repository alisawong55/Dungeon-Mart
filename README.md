# Dungeon-Mart
## Project info
- **Unity Version:** 6000.0.56f1
- **Platform:** Android (Portrait)
- **Supported Aspect Ratios:** 16:9, 19.5:9

## Setup Instructions
1. Clone repository "git clone https://github.com/alisawong55/Dungeon-Mart.git"
2. Open project with the following unity version.
3. Select simulate device to test or built to android APK.
## Shop Structure
- **Sections:**
  - Potion
  - Equip
  - Premium
- **Currencies:**
  - Coin (soft currency)
  - Gem (hard currency, premium)
- **Features:**
  - Item Card UI
  - Purchase system (Subtract coin/gem, Check currency amount, Add item to inventory)
  - Navigation between sections
  - Responsive UI
## Project Structure (Overview)
- **Audio/**
  BuySell, Denied
- **Prefabs/**
  ItemIcon, PopupText
- **Resources/**
  Equip, Potion, Premium
- **Scripts/**
  AudioController, Item, ItemIcon, SafeArea, SaveData, ShopUI, TimedSelfDestruct, UIManager, UITextPopup
- **Sprites/**
  Item UI sprite, currency icon
- **Scenes/**
  ShopScene

## Technical Decisions
- **UI Framework (uGUI + Canvas Scaler)** Set Scale With Screen Size with reference resolution 1080x1920 to ensure responsive design across 16:9 and 19.5:9 devices.
- **Safe Area Handling** Implement Safe Area Helper to prevent UI from overlapping the notch on mobile.
- **Data Handling (ScriptableObject)** Use ScriptableObject for configuring currency values, making it reusable.
- **Navigation** Use tab system, easy section switching and future expansion.
## Known Issues
- **Basic Visual Feedback** Implement only SFX feedback and popup text.
- **Data Management** Item data is loaded via JSON but lacks localization support.
- **No Persistence** Persistence has not been performed (purchased items are not saved when the game is closed)
