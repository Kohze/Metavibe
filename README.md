
![Protocol](https://img.shields.io/badge/Protocol-BitcoinSV-yellow.svg)
![Framework](https://img.shields.io/badge/Framework-ReactNative-blue.svg)
![GitHub contributors](https://img.shields.io/github/contributors/Kohze/Metavibe.svg)
![GitHub issues](https://img.shields.io/github/issues-raw/kohze/Metavibe.svg)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/Kohze/fireData/master/LICENSE.txt)
![MetaVibe](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2FheadTitle.jpg?alt=media&token=be4e0fd2-823c-4151-bfb1-dd528bd0ee9d)



MetaVibe creates a location based meta layer on top of our physical world. Thereby allowing to drop media content, comments and other smart contract based events to specific locations while ensuring that only people at the location can read the content. Here we present the functional prototype (Android & iOS) aswell as the open protocoll of MetaVibe. 


![Frameworks](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2FScreenshot_21.jpg?alt=media&token=8d7535f0-e28b-47a6-b279-01c28228ca34)



![Showcase](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2FShowcase.jpg?alt=media&token=cc890401-72cd-4061-85da-8bb3c1dee9b6)

![Mockup](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2FS7_mockup_preview_2.jpg?alt=media&token=918fde02-a1d3-4af1-b496-6ad6506cfdc7)

![Application](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2FApplication.jpg?alt=media&token=b0594a8e-8386-4302-a5e1-6d98b3af5910)

While social media enables us to find a variety of connections and events, they also take away a sense of locality and the willingness to explore the unknown. Here we connect user experience of reddit (multi-interest heterogeneity) with the excitement of roleplay games (solving quests) and the exploration aspect of augmented reality games. 

![GardenImage](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2Fgarden_image.jpg?alt=media&token=5272faff-5b01-4a13-adae-7414f8029e97)

Our pitch: https://docs.google.com/presentation/d/1uQmfxb2AVT_-3oyqTLf3y6_SEYECJtXFnrpyalp2diM/edit?usp=sharing


![Use Cases](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2Fuse_cases.jpg?alt=media&token=a5d8c9ba-e4e4-41f4-bad0-dcdeecf4b021) 




- Place editable content to specified places to enrich user experience and knowledge
- Follow local creators and see the places they placed content. The content will have the handle, identifier, qualifications of the person who added it (adds credibility/weight to the content)
- User can select a city tour based entirely on content uploaded by content loaders
eg Kings college professor uploads a history of kings college chapel, including personal anecdotes about his experience of the chapel 
- phone of user buzzes when reaching a site with previously specified content
- boosting tourist numbers and experience at tourist locations
- Adoption and onboarding: Users can receive bitcoin for solving quests and challenges. Businesses owners can share rewards for coming to their location. Thereby boosting costumer & tourist numbers and experience.
- Beacon wallet that is static to defined places to preserve historic sites/natural spaces/local wildlife
- Local donations: visitors deposit small fee after enjoying interacting with that space
- Smart contract based unlocking: facial recognition software to identify the individual and transfer bitcoin-based currency
- Message dropping: leaving messages/media at specified locations
eg song recommendation for that particular geographic location
- Filter ‘Vibes’ by type to see only content of interest
- Access side specific media content: poem written about that site, book recommendations about the site, photos taken at the site (and get rewarded by tipping mechanism)
- Add content to monuments: visiting former home/gravesite of famous person - access biography, interactive content on their life
- Messages and comment thread attached to a geographic location (location specific reddit threads)
- including jokes from previous visitors 
- can add to the banter/chat around the statue/site/location
- can vote for best jokes/puns on each location
- Content creator tipping: can make small payments to best joke/pun
- good for people travelling alone to tap into the kind of experience group travellers have - ie the interpretation/cultural interaction/experiencing of the sights/locations
- getting location based ticket for event in proximity (eg a museum, niche concert)
- Rewarded in micropayments for: Reading warning signs for X seconds
- Accessing premium virtual tours all around the city (audiobooks and description)
- Create activity challenges: local users upload recommended jogging routes in the area. Get rewarded for completing challenges 
- Trip Advisor: useful for visitors who don’t know the lie of the land (eg quiet backstreets, good parks)
- Value and reward ecosystem: getting tipped for interesting insights left behind 
- Location based transfers: drop bitcoins to everyone at the current location or conference 
- “green” list of valuable locations connected with information child/family friendly content


![AR](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2Far.jpg?alt=media&token=79f614b2-7579-4037-a6c1-8957347e7173)

Augmented reality (AR) is used to allow users to visualize messages in their visible environment in real time. The AR messages track with the physical movement of the user's device, allowing them to see and interact with the messages at their precise location as they move/walk. The message location within the AR portion of the app is shown at a specific height above the ground, allowing content creators to place messages at, for example, façades of buildings or on billboards, etc.

An AR application, to be embedded within the main React Native app, allows the virtual visualization of messages (represented as tap-able icons) at their real location. The user’s camera provides the background of the image; live GPS location allows dynamic loading of messages within a reasonable distance. Messages have a 3-component location associated with them, so their corresponding icons can be placed in the correct location on the camera feed. The React Native app will communicate with the blockchain, and send a list of nearby messages to the Unity AR app, which will then process their location data and render the virtual icons in real time [MessageAR2/Assets/TapObject.cs]. Downloadable demo version for Android, currently in alpha stage development and featuring moving message icons simulating a user walking down a street, is at [MessageAR2/MetaVibeAR.apk] (NB: the full AR functionality is currently only available on some devices; see ![Vuforia supported devices](https://library.vuforia.com/articles/Solution/vuforia-fusion-supported-devices.html).

Quick facts: 

- AR mockup: https://3yqf6b.axshare.com
- Made with Unity/Vuforia, the leading platform for fully-featured AR development
- Allows users to interact with messages in their physical 3-D location
- Icons stay where they belong in space even as user pans their phone around the environment
- Highly extensible and customizable - beta stage implementation will include customized message icons, etc.

![Challenges](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2FChallenge.jpg?alt=media&token=aeb27abd-b775-466c-a8b2-1c0e6b0ab438) 

**Getting users onto the app**
- what initial motivation?
- sticker on the physical location - “download this app for more information on this site”
- starts to build awareness of the app’s existence and build broader interest 
- how do they find out about the app

**Initial bitcoin injection**
- payments from advertisers seeking to connect with their customers
- ie customer gets paid to accept ads from products they already enjoy

**Medium/long term bitcoin ecosystem**
- users uploading content get paid in micro-payments
- incentivises good quality/tailored content

![Ecosystem](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2Fecosystem.jpg?alt=media&token=9bc39d81-2bbe-4e36-a516-fb093c9e48d3)

![ecosystemImage](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2Feco_screenshot.jpg?alt=media&token=0657db20-b347-457d-af1c-bd2b619a17e2)

MetaVibe Introduces an extensible blockchain environment for a variety of applications under the same base protocol and same dataset. Therefore, businesses might develop commercially optimised apps that add and access the same environment. MetaVibe is a high level user experience focused Android and iOS implementation within the ecosystem.

op_return scheme:

- [1] protocolID (MetaVibeAlpha)
- [2] open message title
- [3] open message
- [4] type (to enable filtering)
- [5] location: longitude
- [6] location: latitude
- [7] image
- [8] persistence time
- [9] encryption type (msg, wifi, image catpcha)
- [10] secret message (encrypted) 
- [11] uploader (to enable following people)


![Insights](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2FInsights.jpg?alt=media&token=9d9c46af-f579-4903-9a08-eff49dd97f42)


Location specific code:

Code for creating a list of local wifi networks

https://github.com/devstepbcn/react-native-android-wifi


**GPS + BSSID**
- content uploader must visit the geographic location in order to deposit the content
- the list of SSIDs it detects as it adds the content will form part of the authentication mechanism (along with GPS coordinates)
- Downside of this: restricts content contributors to locals
- Positive of this: keeps the ‘hyperlocality’ nature of the app
- this is key value add of MetaVibe 
- facebook, twitter, wikipedia allow content to be shared with individuals across the globe 
but they are sharing a purely ‘online’ interaction
- this app allows content to be shared at a specific physical location, through different temporal landscapes → with the option to 

```
Eg: Wifi networks near King’s College Chapel
Latitude: 52.2045 to 52.2049
Longitude: 0.1161 to 0.1173
‘events’ BSSID: 26:a4:3c:bb:d1:a9
‘eduroam’ BSSID: 36:a4:3c:bb:d1:a9
‘eduroam’ BSSID: 2e:a4:3c:bb:df:ae
‘Guest-Rms’ BSSID: 1c:af:f7:2e:2e:3d
‘e_network’ BSSID: 7c:d1:c3:ca:05:68
‘_TheCloud’ BSSID: c4:10:8a:19:b3:68
‘BTOpenzone-CaffeNero’ BBSID: 00:1e:13:45:29:21
Honor 8 Lite, BSSID: 50:04:b8:2b:b5:b0
sparessid, BSSID: 32:a4:3c:bb:df:ae
guests, BSSID: 24:a4:3c:df:a0:6a
```


![Legal](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2FLegal.jpg?alt=media&token=175af31e-dbbd-4b0b-aa23-ca8e54f70060)

**1. Illegal or harmful content uploaded to MetaVibe**

The UK is looking to introduce the first online safety laws of their kind late 2019 or 2020, placing new obligations on social media companies and tech firms to protect their users and face tough penalties if they do not comply.

In the offline world the owners of physical spaces owe a duty of care to visitors. The drafters of the new UK law are considering a parity principle in which owners of online services are also required to take reasonable measures to prevent harm. MetaVibe would face such a duty of care towards its users as the host of content uploaded by its users.

Not all harms that users face in the digital world are easily identifiable illegal harms. Some online harms have a clear legal definition, such as child pornography, terrorist content and encouraging or assisting suicide. Other harms with a less clear legal definition in the online space include cyberbullying, offensive or extremist content and advocacy of self-harm.
  
The MetaVibe developers seek to address these concerns of harmful/offensive content uploaded to the app by:
- Green listing content to enable family friendly version [currently in planning, not yet integrated]
- Blacklisting of offending content creators [currently integrated]
- User rating system to promote trusted/reliable content creators and assist in identifying offensive material
- User accounts linked to a bitcoin wallet to enhance accountability
- a limited liability policy to address unreasonable behavior from users of MetaVibe who do not respect legal and non-harmful content requirements
- Removing the harmful data from the app
 
**2. Consumer Privacy Protection**

The UK’s Data Protection Act 2018 places obligations on businesses in handling personal information from customers. These obligations require that such information is handled in a way that ensures appropriate security, including protection against unauthorized access or destruction. This includes protecting the security of financial transactions occurring on the app. 

MetaVibe will utilise user logins via the MoneyButton app. Users will first need to sign up to the MoneyButton app to create a bitcoin wallet to be used to transfer micropayments used to view other users’ content or upload their own content to the app. The MetaVibe app developers will not require users to provide full personal information (e.g. real name or DOB) to MetaVibe. The MoneyButton bitcoin wallet will function as the secure payment processing mechanism for all transactions on MetaVibe.

**3. Intellectual Property Protection**

Given that MetaVibe will serve as a largely open source platform, the users uploading content will retain copyright over their work loaded to the app. 
MetaVibe will secure the IP behind the app concept via patent with the UK Intellectual Property Office and file an application with the European Patent Office and WIPO International Patent System to enable IP protection across more than 140 countries. 

Sources:
(1) The Malicious Communications Act 1988 prohibits the sending of messages which are threatening or grossly offensive; it applies whether the message is through the post or through any form of electronic communication. The Computer Misuse Act 1990 targets online behaviour, introducing criminal liability for hacking and other unauthorised access or modification of computer material.

![Demo](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2Fdemo.jpg?alt=media&token=5106de9f-e600-4f2d-8b79-caefede9187b)

Install: 
clone repo, then:
- yarn install
- yarn start

Quick peek at Android demo via Expo App in Google Playstore: exp://172.29.13.101:19000

![Team](https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2FTeam.jpg?alt=media&token=9371a023-4fb9-43af-986a-77a70aa5e42e)

- Robin Kohze, PhD Student, Cambridge Department of Genetics
- Chris Maits, MPhil Student, Cambridge Law
- Reina Nakamoto, Professional Game Designer 
- Noah Kessler, PhD Student, Cambridge Department of Genetics
- Gioia Riboni-Verri, MPhil Student, Cambridge Life Sciences
