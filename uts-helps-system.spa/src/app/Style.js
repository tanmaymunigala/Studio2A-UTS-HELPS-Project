/*
 * This fixes the positioning of the main components
 *
 * @auther: Wai Leong Lau      @Date: 07/03/2018
 */

// Header custom Style
const Style = theme => ({
    // App bar
    root: {
      display: "flex",
      flexDirection: "column",
      minHeight: "100vh"
    },
    content: {
      flex: "1 0 auto",
      position: "relative"
    },
    footer: {
      flexShrink: 0
    }
  });
  
  export default Style;
  