# ActivitiyManagerApi

The purpose of the Activity Manager application is to provide a platform for managing activities and their details. It aims to simplify the process of editing and maintaining various events by offering features such as creating, updating and deleting events, managing event details, associating images with events, managing locations and tickets, and discovering relationships between different entities.

## Classes and Tables

The project includes the following classes and tables:

1. **Activity**
   - Id: Activity ID (primary key).
   - Title: Activity title (optional).
   - Description: Activity description (optional).
   - Images: Collection of images associated with the activity.
   - ActivityDetails: Collection of activity details.

2. **ActivityCategory**
   - Id: Activity category ID (primary key).
   - Name: Activity category name.

3. **ActivityDetail**
   - Id: Activity detail ID (primary key).
   - StartDate: Start date and time of the activity.
   - EndDate: End date and time of the activity (optional).
   - Description: Description of the activity detail (optional).
   - ActivityCategoryId: ID of the activity category (foreign key).
   - ActivityCategory: Relationship with the activity category.
   - ActivityId: ID of the activity (foreign key).
   - Activity: Relationship with the activity.
   - PlaceId: ID of the place where the activity takes place (foreign key).
   - Place: Relationship with the place.
   - TicketId: ID of the ticket associated with the activity detail (foreign key).
   - Ticket: Relationship with the ticket.

4. **Image**
   - Id: Image ID (primary key).
   - ImageUrl: URL of the image.
   - ActivityId: ID of the activity associated with the image (foreign key).
   - Activity: Relationship with the activity.

5. **Place**
   - Id: Place ID (primary key).
   - Name: Place name.
   - City: City.
   - District: District.
   - Address: Address (optional).
   - MapUrl: URL of the map.
   - ActivityDetails: Collection of activity details associated with the place.

6. **Ticket**
   - Id: Ticket ID (primary key).
   - Price: Ticket price.
   - TicketCategoryId: ID of the ticket category.
   - TicketCategory: Relationship with the ticket category.
   - ActivityDetails: Collection of activity details associated with the ticket.

7. **TicketCategory**
   - Id: Ticket category ID (primary key).
   - Name: Ticket category name.
   - Tickets: Collection of tickets associated with the ticket category.

## Usage

The project is used for managing activities. You can perform operations such as listing activities, creating new activities, managing activity details, adding and removing images, managing places and tickets, and querying data using database relationships. Additionally, you can generate reports and query data using the database relationships.

## Database Relationships

The project is primarily based on the ActivityDetail table, which establishes relationships with other tables. The relationships are as follows:

- ActivityDetail -> Activity: An activity detail belongs to an activity.
- ActivityDetail -> ActivityCategory: An activity detail belongs to an activity category.
- ActivityDetail -> Place: An activity detail takes place at a specific place.
- ActivityDetail -> Ticket: An activity detail is associated with a ticket.
- Activity -> Image: An activity can have multiple images.
- Activity -> ActivityDetail: An activity can have multiple activity details.
- ActivityCategory -> ActivityDetail: An activity category can have multiple activity details.
- Place -> ActivityDetail: A place can have multiple activity details.
- Ticket -> ActivityDetail: A ticket can be associated with multiple activity details.
- TicketCategory -> Ticket: A ticket category can have multiple tickets.

You can leverage these relationships to query data from related tables and perform database operations.

![database image](C:\Users\busra\OneDrive\Masaüstü\images\database.png)

## Contact

If you have any questions, suggestions, or feedback, please email us at [bsrctkk@gmail.com]
