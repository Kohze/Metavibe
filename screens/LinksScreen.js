import React from 'react';
import { ScrollView, StyleSheet } from 'react-native';
import { Searchbar, Avatar, Button, Card, Title, Paragraph } from 'react-native-paper';


export default class LinksScreen extends React.Component {

  state = {
    firstQuery: '',
  };

   static navigationOptions = {
    header: null,
  };


  render() {
    const { firstQuery } = this.state;

    return (
    <ScrollView style={{backgroundColor: 'rgba(0,0,0,0.1)'}} >
       <Searchbar
          style={{margin: 5, marginTop: 30}}
          placeholder="Search"
          onChangeText={query => { this.setState({ firstQuery: query }); }}
          value={firstQuery}
       />
      
       <Card style={{margin: 5}}>
        <Card.Content style={{paddingBottom: 10}}>
          <Title>Park Meetup</Title>
          <Paragraph>20s meetup at the park at 16:00</Paragraph>
        </Card.Content>
        <Card.Cover source={{ uri: 'https://placeimg.com/640/480/nature?t=1557059912909' }} />
       </Card>
       <Card style={{margin: 5}}>
        <Card.Content style={{paddingBottom: 10}}>
          <Title>Trinity College Tour</Title>
          <Paragraph>I am giving tour for up to 4 persons at 15:00</Paragraph>
        </Card.Content>
        <Card.Cover source={{ uri: 'https://placeimg.com/640/480/arch?t=1557059841181' }} />
       </Card>
       <Card style={{margin: 5}}>
        <Card.Content style={{paddingBottom: 10}}>
          <Title>Football Evening</Title>
          <Paragraph>Watching the Champions League final</Paragraph>
        </Card.Content>
        <Card.Cover source={{ uri: 'https://placeimg.com/640/480/arch?t=1557059841188' }} />
       </Card>
            <Card style={{margin: 5}}>
        <Card.Content style={{paddingBottom: 10}}>
          <Title>Kings College Audio Guide</Title>
          <Paragraph>A audio guide from the world reknown historian Holgar King</Paragraph>
        </Card.Content>
        <Card.Cover source={{ uri: 'https://placeimg.com/640/480/arch?t=1557059841185' }} />
       </Card>
            <Card style={{margin: 5}}>
        <Card.Content style={{paddingBottom: 10}}>
          <Title>What just happened here?</Title>
          <Paragraph>Looks we just had a major accident just seconds ago</Paragraph>
        </Card.Content>
       </Card>
       <Card style={{margin: 5}}>
        <Card.Content style={{paddingBottom: 10}}>
          <Title>Climbing at Kelsey Kerridge</Title>
          <Paragraph>Weekly Bouldering at 17:00</Paragraph>
        </Card.Content>
        <Card.Cover source={{ uri: 'https://placeimg.com/640/480/arch?t=1557059841174' }} />
       </Card>
    </ScrollView>
    );
  }
}
