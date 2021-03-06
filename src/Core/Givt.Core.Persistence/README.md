# Givt.Domain

## Introduction
This project contains the data model, or Domain, in a set of classes
The main focus of the domain is the Campaign. These are Owned (or supported) Recipients (a form of LegalEntity). 
These are usually organisations, but possibly also private persons.

## MVP
The current Domain contains Entities needed for a Minimal Viable Product.

## Campaign
The Campaign is the central Entity in the Donation flow; Every Donation is linked to a Campaign.

In the traditional church context, the campaigns can be seen as a representative of the collection or collection purpose. In other contexts, it could be recognisable activity or focus of the charity. For a festival, it can be something like a band or artist.

## Entry
The app user (or donor) "enters" the domain through a variety of means. These all lead in the end to a Campaign:
1. Medium - Beacon, QR Code, Location, hyperlink on a web site etc. 
- Each medium is usually linked to 1 campaign. When the user enters through one of these, the Campaign is direclty selected.
- A medium or location does not need to be linked to a Campaign directly, but can also be linked to a (list of) Timeslot(s). Based on the current time, a campaign is then selected. Use cases are:
    - Beacon attached to a collection bag or bucket
    - QR code on a collection box
    - Stages at a festival with several bands performing according to a roster
- A Medium can even be not linked to a Campaign nor any active Location. This allows for multiple scenarios:
    - the flow goes to the Recipient, linked campaigns are shown to the user
    - the user swill be presented a list of Timeslots from the near past and near future for this Medium (e.g. if a band at a festival gives an encore passed the programmed TimeSlot, or a church member wants to donate to a Collect after the service)
2. Recipient - Selection of an Recipient in the app. The user is subsequently presented with the Campaigns owned (or "supported") by the Recipient. The user selects an Recipient/Campaign.
3. Actuality - A big event in the world such as a disaster, famine, war. When the user selects the actuality, a list of Recipients with Campaigns linked to the Actuality is presented. The user selects a Campaign supported by its Recipient.

### Notes
- Calculated Fees rounded to cents in campaign reports 
- (re-)allocating donations does not change calculated fees & cost allocation

## Missing Features / Not in the Domain
- It is easy to add payment methods
- Reporting (in NoSQL?)

## Future
- Other Entities not in the MVP
- Donation Matching. Explanation: Some Donors like to motivate other Donors: "If someone gives X amount, I'll double it".

