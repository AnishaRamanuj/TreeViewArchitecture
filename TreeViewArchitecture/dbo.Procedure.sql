CREATE PROCEDURE GetActiveNodes
AS
BEGIN
    SELECT NodeId, NodeName, ParentNodeId, IsActive, StartDate
    FROM Nodes
    WHERE IsActive = 1
END
