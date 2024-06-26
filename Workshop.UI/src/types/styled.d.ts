import "styled-components";

declare module "styled-components" {
  export interface DefaultTheme {
    colors: {
      primary: string;
      secondary: string;
      thernary: string;
      background: string;
    };
    font: {
      sm: string;
      md: string;
      lg: string;
      xl: string;
      weight: {
        light: number;
        medium: number;
        semibold: number;
        bold: number;
      };
    };
    borderRadius: string;
  }
}
