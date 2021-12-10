<template>
  <showcase-create v-bind="createData" @onSend="createAgent($event)"/>
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import {
  required,
  maxLength,
  minLength,
  numeric,
  email,
  phone
} from '@/utils/validation/i18n-validators'

export default {
  name: 'AgentCreate',
  components: {
    ShowcaseCreate
  },
  data: () => {
    return {
      createData: {
        title: 'Создать контрагента',
        fields: [
          {
            label: 'Наименование',
            placeholder: 'Наименование',
            modelValue: 'name',
            validation: { required }
          },
          {
            label: 'Адрес',
            placeholder: 'Адрес',
            modelValue: 'address',
            validation: { required }
          },
          {
            label: 'Тип',
            placeholder: 'Тип контрагента',
            type: 'select',
            modelValue: 'agentType',
            cols: ['col-md-4'],
            validation: { required },
            values: [
              {
                text: 'Утилизатор',
                value: 'util'
              },
              {
                text: 'Клиент',
                value: 'client'
              },
              {
                text: 'Поставщик',
                value: 'supplier'
              },
              {
                text: 'ТК',
                value: 'tk'
              }
            ]
          },
          {
            label: 'ИНН',
            placeholder: 'ИНН',
            modelValue: 'inn',
            validation: {
              required,
              numeric,
              minLength: minLength(10),
              maxLength: maxLength(12)
            },
            cols: ['col-md-4']
          },
          {
            label: 'Расчетный счет',
            placeholder: 'Расчетный счет',
            modelValue: 'bill',
            validation: {
              required,
              numeric,
              minLength: minLength(20),
              maxLength: maxLength(20)
            },
            cols: ['col-md-4']
          },
          {
            label: 'Телефон',
            placeholder: 'Телефон',
            modelValue: 'phone',
            type: 'tel',
            validation: { required, phone }
          },
          {
            label: 'Электронная почта',
            placeholder: 'Электронная почта',
            modelValue: 'email',
            type: 'email',
            validation: { required, email }
          }
        ]
      }
    }
  },
  methods: {
    createAgent (data) {}
  }
}
</script>
