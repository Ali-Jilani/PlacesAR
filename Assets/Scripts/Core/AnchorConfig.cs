using UnityEngine;

/// <summary>
/// ScriptableObject configuration for AR cloud anchors with GPS positioning data.
/// </summary>
[CreateAssetMenu(fileName = "AnchorConfig", menuName = "PlacesAR/Anchor Config")]
public class AnchorConfig : ScriptableObject
{
    /// <summary>
    /// The unique identifier for the cloud anchor.
    /// </summary>
    [SerializeField]
    [Tooltip("The unique Cloud Anchor ID from ARCore/ARKit")]
    private string cloudAnchorId;

    /// <summary>
    /// GPS latitude coordinate in degrees (-90 to 90).
    /// </summary>
    [SerializeField]
    [Range(-90f, 90f)]
    [Tooltip("GPS latitude in degrees (-90 to 90)")]
    private double latitude;

    /// <summary>
    /// GPS longitude coordinate in degrees (-180 to 180).
    /// </summary>
    [SerializeField]
    [Range(-180f, 180f)]
    [Tooltip("GPS longitude in degrees (-180 to 180)")]
    private double longitude;

    /// <summary>
    /// GPS altitude in meters above sea level.
    /// </summary>
    [SerializeField]
    [Tooltip("GPS altitude in meters above sea level")]
    private double altitude;

    /// <summary>
    /// Heading offset in degrees to align virtual content with the real world.
    /// </summary>
    [SerializeField]
    [Range(-180f, 180f)]
    [Tooltip("Heading offset in degrees to align content")]
    private float headingOffset;

    /// <summary>
    /// Whether to enable GPS-based fallback positioning when cloud anchor resolution fails.
    /// </summary>
    [SerializeField]
    [Tooltip("Enable GPS fallback when cloud anchor resolution fails")]
    private bool fallbackEnabled;

    /// <summary>
    /// Maximum time in seconds to wait for cloud anchor resolution.
    /// </summary>
    [SerializeField]
    [Min(1f)]
    [Tooltip("Cloud anchor resolution timeout in seconds")]
    private float cloudAnchorTimeout = 15f;

    /// <summary>
    /// Gets the Cloud Anchor ID.
    /// </summary>
    public string CloudAnchorId => cloudAnchorId;

    /// <summary>
    /// Gets the GPS latitude in degrees.
    /// </summary>
    public double Latitude => latitude;

    /// <summary>
    /// Gets the GPS longitude in degrees.
    /// </summary>
    public double Longitude => longitude;

    /// <summary>
    /// Gets the GPS altitude in meters.
    /// </summary>
    public double Altitude => altitude;

    /// <summary>
    /// Gets the heading offset in degrees.
    /// </summary>
    public float HeadingOffset => headingOffset;

    /// <summary>
    /// Gets whether fallback positioning is enabled.
    /// </summary>
    public bool FallbackEnabled => fallbackEnabled;

    /// <summary>
    /// Gets the cloud anchor resolution timeout in seconds.
    /// </summary>
    public float CloudAnchorTimeout => cloudAnchorTimeout;

    /// <summary>
    /// Validates that the configuration has all required data and values are within acceptable ranges.
    /// </summary>
    /// <returns>True if the configuration is valid, false otherwise.</returns>
    public bool IsValid()
    {
        if (string.IsNullOrWhiteSpace(cloudAnchorId))
            return false;

        if (latitude < -90.0 || latitude > 90.0)
            return false;

        if (longitude < -180.0 || longitude > 180.0)
            return false;

        if (cloudAnchorTimeout <= 0f)
            return false;

        return true;
    }

    /// <summary>
    /// Gets a validation error message if the configuration is invalid.
    /// </summary>
    /// <returns>Error message string, or null if configuration is valid.</returns>
    public string GetValidationError()
    {
        if (string.IsNullOrWhiteSpace(cloudAnchorId))
            return "Cloud Anchor ID is required.";

        if (latitude < -90.0 || latitude > 90.0)
            return $"Latitude must be between -90 and 90. Current value: {latitude}";

        if (longitude < -180.0 || longitude > 180.0)
            return $"Longitude must be between -180 and 180. Current value: {longitude}";

        if (cloudAnchorTimeout <= 0f)
            return $"Cloud Anchor Timeout must be positive. Current value: {cloudAnchorTimeout}";

        return null;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        // Clamp values to valid ranges
        latitude = System.Math.Clamp(latitude, -90.0, 90.0);
        longitude = System.Math.Clamp(longitude, -180.0, 180.0);

        if (cloudAnchorTimeout < 1f)
            cloudAnchorTimeout = 1f;

        // Log warning if Cloud Anchor ID is empty
        if (string.IsNullOrWhiteSpace(cloudAnchorId))
        {
            Debug.LogWarning($"[{name}] Cloud Anchor ID is empty.", this);
        }
    }
#endif
}
