# Week2_Challenge
SSC_Unity_6gen_InputSystem,GenericSingleton,ObjectPool

**<Q1. Input Rebinding>**  
![Q1  Input Rebingding](https://github.com/user-attachments/assets/1c1049a3-7a8d-4c6e-9061-4d120fe7a241)
▲Input Rebinding gif  

**[구현 사항 0]**  
Input System을 import 하고, `Input Action` Challenge를 구성하세요.  
**[구현 사항 1]**  
`InputRebinder` 클래스의 actionAsset에서 Space 액션을 찾고 활성화합니다.  
**[구현 사항 2]**  
`InputRebinder` 클래스의 `RebindSpaceToEscape` 메소드를 **ContextMenu 어트리뷰트**를 활용해서 **인스펙터창에서 우클릭으로 실행**할 수 있도록 합니다.  
**[구현 사항 3]**  
`InputRebinder` 클래스의 `RebindSpaceToEscape` 함수는 **기존 Spacebar 키**를 입력하던 액션을 **Escape키를 입력했을 때 발생**하도록 합니다.  
  

**<Q2. Generic Singleton>**
![Q2  Generic Singleton](https://github.com/user-attachments/assets/bdd2dd28-a791-4838-bed9-b30c29a610c0)  
▲Generic Singleton gif  
![Q2  Generic Singleton](https://github.com/user-attachments/assets/ba1d003c-cd8d-4518-9c83-639f902a8a89)  
▲Generic Singleton ,Audio Manager 코드  
  
**[구현 사항 1]**  
Instance 프로퍼티의 get 부분을 완성하세요. 이때 다양한 문제 상황에 대한 대응을 포함해야 함을 생각해두세요. (미할당인 경우, 생성되지 않은 경우)  
**[구현 사항 2]**  
`Singleton<T>`를 상속받는 컴포넌트를 포함한 게임오브젝트는 다른 씬으로 넘어가도 파괴되지 않게 하세요. 이때, 누군가의 자식일 때는 이에 대한 루트 컴포넌트 전체가 해당 특성이 적용되도록 하세요.  
**[구현 사항 3]**   
`Singleton<T>`를 상속받는 `AudioManager`를 처음부터 구현하세요. 간단한 bgm을 플레이하도록 하세요.  
  
**<Q3. Object Pool 끝장보기>**
![image](https://github.com/user-attachments/assets/5fc7be59-6623-4b0a-ab0e-5f7fdc70dccf)

원하는 오브젝트 풀을 활성화 시키고 키를 조작하면 오브젝트 풀이 동작합니다.
**SpaceBar** : 오브젝트 10개씩 생성하기
**ESC** : 월드에 있는 오브젝트 전부 반납(Release) 하기

**[구현사항 1]**   
최소 50개의 오브젝트 수 보장, 부족할 경우 누적 300개까지 추가 생성, 300개가 넘어갈 경우 임시로 생성 후 반환 시 파괴  
**[구현사항 2]**   
최소 50개의 오브젝트 수 보장, 부족할 경우 누적 300개까지 추가 생성, 300개가 넘어갈 경우 가장 오래전에 생성된 오브젝트를 반환 후 재사용  
**[구현사항 3]**  
오브젝트를 미리 생성하지 않고 부족할 경우 누적 100개까지 추가 생성, 100개가 넘어갈 경우 임시로 생성 후 반환 시 파괴  
**[구현사항 4]**   
이 중 하나를 UnityEngine.Pool을 활용하여 구현 -> **[구현사항 2]** 를 구현하였습니다.

